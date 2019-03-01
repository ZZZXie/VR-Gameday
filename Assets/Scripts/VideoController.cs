using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoController : MonoBehaviour {
    /// <summary> 
    /// Provides Singleton-like behaviour to this class. 
    /// </summary> 
    public static VideoController instance;

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
    private int cur_vid_index;

    /// <summary> 
    /// Reference to the Inside-Out Sphere. 
    /// </summary> 
    public GameObject sphere;

    void Awake() {
        instance = this;
    }
    // Use this for initialization
    void Start () {
        Application.runInBackground = true;
        cur_vid_index = 0;
        StartCoroutine(PlayVideo());
    }

    private IEnumerator PlayVideo() {
        // create a new render texture to display the video 
        videoStreamRenderTexture = new RenderTexture(2160, 1440, 32, RenderTextureFormat.ARGB32);

        videoStreamRenderTexture.Create();

        // assign the render texture to the object material 
        Material sphereMaterial = sphere.GetComponent<Renderer>().sharedMaterial;

        //create a VideoPlayer component 
        videoPlayer = gameObject.AddComponent<VideoPlayer>();

        // Set the video to loop. 
        videoPlayer.isLooping = true;

        // Set the VideoPlayer component to play the video from the texture 
        videoPlayer.renderMode = VideoRenderMode.RenderTexture;

        videoPlayer.targetTexture = videoStreamRenderTexture;

        // Add AudioSource 
        audioSource = gameObject.AddComponent<AudioSource>();

        // Pause Audio play on Awake 
        audioSource.playOnAwake = true;
        audioSource.Pause();

        // Set Audio Output to AudioSource 
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.source = VideoSource.VideoClip;

        // Assign the Audio from Video to AudioSource to be played 
        videoPlayer.EnableAudioTrack(0, true);
        videoPlayer.SetTargetAudioSource(0, audioSource);

        // Assign the video Url depending on the current scene 
        switch (SceneManager.GetActiveScene().name) {
            case "VideoScene1":
                videoPlayer.clip = videos[0];
                break;

            case "VideoScene2":
                videoPlayer.clip = videos[0];
                break;

            case "VideoScene0":
                videoPlayer.clip = videos[0];
                break;

            default:
                break;
        }

        //Set video To Play then prepare Audio to prevent Buffering 
        videoPlayer.Prepare();

        while (!videoPlayer.isPrepared) {
            yield return null;
        }

        sphereMaterial.mainTexture = videoStreamRenderTexture;

        //Play Video 
        videoPlayer.Play();

        //Play Sound 
        audioSource.Play();

        while (videoPlayer.isPlaying) {
            yield return null;
        }
    }

    public void ChangeVideo(GameObject SwitchVideoText) {
        //More Scenes?
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name == "VideoScene1" ? "VideoScene2" : "VideoScene1");
        //if (SceneManager.GetActiveScene().name == "VideoScene0")
        //    SceneManager.LoadScene("VideoScene1");
        //if (SceneManager.GetActiveScene().name == "VideoScene1")
        //    SceneManager.LoadScene("VideoScene2");
        //if (SceneManager.GetActiveScene().name == "VideoScene2")
        //    SceneManager.LoadScene("VideoScene0");
        cur_vid_index++;
        if (cur_vid_index == 3) cur_vid_index = 0;
        videoPlayer.clip = videos[cur_vid_index];
        SwitchVideoText.SetActive(true);
        Debug.Log("Changed");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
