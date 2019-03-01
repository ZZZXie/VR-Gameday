using HoloToolkit.Unity;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.Receivers;
using HoloToolkit.Unity.InputModule;
using RenderHeads.Media.AVProVideo;

public class ButtonReceiver : InteractionReceiver
{
    public TextMesh chatButtonText;
    public GameObject ChatHistoryPanel;
    public GameObject ChatInputPanel;
    public GameObject ChannelSelection;
    public MediaPlayer mp;
    private int counter = 0;
    void Start()
    {
        //Debug.Log(GameObject.Find("Toolbar"));
        //Debug.Log(GameObject.Find("Toolbar").transform.Find("ToolbarButton4"));
        //chatButtonText = GameObject.FindGameObjectWithTag("Toolbar").transform.Find("ToolbarButton4").GetComponent<TextMesh>();
        //mp = GameObject.FindGameObjectWithTag("MediaPlayer").GetComponent<MediaPlayer>();
        //chatObject = GameObject.Find("ChatText");
        //Debug.Log(chatButtonText.text);
    }

    void Update() {
        if (mp == null && VideoControllerNew.instance != null && VideoControllerNew.instance.cur_vid_index == 4) {
            mp = GameObject.FindGameObjectWithTag("MediaPlayer").GetComponent<MediaPlayer>();
        }
        else if (VideoControllerNew.instance != null && VideoControllerNew.instance.cur_vid_index == 4)
        {
            mp.Control.SetVolume(AudioListener.volume);
            if (mp.Control.IsPaused())
            {
                mp.Control.Play();
            }
        }
    }
        
    protected override void InputDown(GameObject obj, InputEventData eventData)
    {
        if (!eventData.PressType.Equals(InteractionSourcePressInfo.Select))
        {
            return;
        }
        if (obj == null || eventData.used) return;
        Debug.Log(obj.name);
        //txt.text = obj.name + " : InputDown";
        switch (obj.name)
        {
            case "VolumeUpButton":
                if (AudioListener.volume < 1)
                {
                    AudioListener.volume += .05f;
                    if (VideoControllerNew.instance.cur_vid_index == 4)
                    {
                        mp.Control.SetVolume(AudioListener.volume);
                    }
                }
                break;
            case "VolumeDownButton":
                if (AudioListener.volume > 0)
                {
                    AudioListener.volume -= .05f;
                    if (VideoControllerNew.instance.cur_vid_index == 4)
                    {
                        mp.Control.SetVolume(AudioListener.volume);
                    }
                }
                break;
            case "ChangeChannelButton":
                // Channel changer
                ChannelSelection.SetActive(!ChannelSelection.active);
                break;
            case "ToggleChatButton":
                BaseSceneManager.Instance.chatEnabled = !BaseSceneManager.Instance.chatEnabled;
                if (BaseSceneManager.Instance.chatEnabled)
                {
                    ChatHistoryPanel.SetActive(true);
                    chatButtonText.text = "Disable Chat";
                }
                else
                {
                    ChatHistoryPanel.SetActive(false);
                    chatButtonText.text = "Enable Chat";
                }
                break;
            case "SendMessageButton":
                //counter++;
                //SharingAPI.Instance.BroadcastInformation("Default User", SharingAPI.commandType.sendChatMessage, VideoControllerNew.instance.cur_vid_index, "Hello World message number " + counter);
                ChatInputPanel.SetActive(!ChatInputPanel.active);
                break;
            case "Channel1Button":
                Debug.Log("button 1");
                VideoControllerNew.instance.ChangeChannel(0);
                break;
            case "Channel2Button":
                Debug.Log("button 2");
                VideoControllerNew.instance.ChangeChannel(1);
                break;
            case "Channel3Button":
                Debug.Log("button 3");
                VideoControllerNew.instance.ChangeChannel(2);
                break;
            case "Channel4Button":
                Debug.Log("button 4");
                VideoControllerNew.instance.ChangeChannel(3);
                break;
            case "Channel5Button":
                Debug.Log("button 5");
                VideoControllerNew.instance.ChangeChannel(4);
                /*Debug.Log(GameObject.FindGameObjectWithTag("MediaPlayer") == null);
                
                mp = GameObject.FindGameObjectWithTag("MediaPlayer").GetComponent<MediaPlayer>();
                Debug.Log(mp);
                mp.Control.SetVolume(AudioListener.volume);*/
                break;
        }
    }

    protected override void InputUp(GameObject obj, InputEventData eventData)
    {
        if (obj == null) return;
        //Debug.Log(obj.name + " : InputUp");
    }
}
