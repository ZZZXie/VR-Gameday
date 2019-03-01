using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoControllerNew : MonoBehaviour
{
    /// <summary> 
    /// Provides Singleton-like behaviour to this class. 
    /// </summary> 
    public static VideoControllerNew instance;

    /// <summary> 
    /// Reference to the Camera VideoPlayer Component.
    /// </summary> 
    private VideoPlayer videoPlayer;

    /// <summary>
    /// Reference to the Camera AudioSource Component.
    /// </summary> 
    private AudioSource audioSource;

    /// <summary> 
    /// Reference to the texture used to project the video streaming 
    /// </summary> 
    private RenderTexture videoStreamRenderTexture;

    /// <summary>
    /// Insert here the first video endpoint
    /// </summary>
    public VideoClip[] videos;
    public int cur_vid_index;

    /// <summary> 
    /// Reference to the Inside-Out Sphere. 
    /// </summary> 
    public GameObject sphere;
    public GameObject LiveSphere;
    public GameObject LiveMedia;
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Application.runInBackground = true;
        cur_vid_index = 0;
        ChatHistoryStorage.Instance.instantiateDictionary();
        StartCoroutine(PlayVideo());
    }

    private IEnumerator PlayVideo()
    {
        // create a new render texture to display the video 
        videoStreamRenderTexture = new RenderTexture(2160, 1440, 32, RenderTextureFormat.ARGB32);

        videoStreamRenderTexture.Create();

        // assign the render texture to the object material 
        Material sphereMaterial = sphere.GetComponent<Renderer>().sharedMaterial;

        //create a VideoPlayer component 
        videoPlayer = GameObject.FindWithTag("MainCamera").AddComponent<VideoPlayer>();

        // Set the video to loop. 
        videoPlayer.isLooping = true;

        // Set the VideoPlayer component to play the video from the texture 
        videoPlayer.renderMode = VideoRenderMode.RenderTexture;

        videoPlayer.targetTexture = videoStreamRenderTexture;

        // Add AudioSource 
        audioSource = GameObject.FindWithTag("MainCamera").AddComponent<AudioSource>();

        // Pause Audio play on Awake 
        audioSource.playOnAwake = true;
        audioSource.Pause();

        // Set Audio Output to AudioSource 
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.source = VideoSource.VideoClip;

        // Assign the Audio from Video to AudioSource to be played 
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetTargetAudioSource(0, audioSource);

        videoPlayer.clip = videos[0];
        
        //Set video To Play then prepare Audio to prevent Buffering 
        videoPlayer.Prepare();

        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }

        sphereMaterial.mainTexture = videoStreamRenderTexture;

        //Play Video 
        videoPlayer.Play();

        //Play Sound 
        audioSource.Play();

        while (videoPlayer.isPlaying)
        {
            yield return null;
        }
    }

    public void ChangeVideo(/* GameObject SwitchVideoText*/)
    {
        int desiredChannel = cur_vid_index + 1;
        if (desiredChannel == 5) desiredChannel = 0;
        ChangeChannel(desiredChannel);
        // SwitchVideoText.SetActive(true);
        Debug.Log("Changed");
    }

    public void ChangeChannel(int i)
    {
        int oldIndex = cur_vid_index; 
        cur_vid_index = i;
        videoPlayer.clip = videos[i];
        if (cur_vid_index == 4)
        {
            loadStream();
        }
        else if (oldIndex == 4)
        {
            unloadStream();
        }
        GameObject chatHistoryText = GameObject.Find("chatText");
        if (chatHistoryText != null) {
            chatHistoryText.GetComponent<ChatMessages>().switchChatChannel(i);
        }
        Debug.Log("Changed" + i);
    }

    public void loadStream()
    {
        //audioSource.Pause();
        if (!audioSource.mute)
        {
            audioSource.mute = !audioSource.mute;
        }
        LiveSphere.SetActive(true);
        LiveMedia.SetActive(true);

        sphere.SetActive(false);
    }

    public void unloadStream()
    {
        //audioSource.Play();
        audioSource.mute = !audioSource.mute;
        LiveSphere.SetActive(false);
        LiveMedia.SetActive(false);
        sphere.SetActive(true);
    }
}
