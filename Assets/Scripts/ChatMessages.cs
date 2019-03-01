using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity;
using UnityEngine;

public class ChatMessages: MonoBehaviour {
    Dictionary<int, List<string>> chatHistory;
    int currentChatChannel; 
    void Start()
    {
        currentChatChannel = VideoControllerNew.instance.cur_vid_index;
        chatHistory = ChatHistoryStorage.Instance.chatMessages;
        switchChatChannel(VideoControllerNew.instance.cur_vid_index);
    }

    void Update()
    {
        if (VideoControllerNew.instance.cur_vid_index != currentChatChannel) {
            switchChatChannel(VideoControllerNew.instance.cur_vid_index);
        }
    }

    public void updateText(int channel, string txt_in) {
        if (VideoControllerNew.instance.cur_vid_index == channel)
        {
            gameObject.GetComponent<TextMesh>().text += txt_in;
        } 
    }

    public void switchChatChannel(int channel)
    {
        currentChatChannel = VideoControllerNew.instance.cur_vid_index;
        Debug.Log(channel);
        gameObject.GetComponent<TextMesh>().text = "Chat Room - Channel " + (channel + 1).ToString() + "\n";
        Debug.Log(channel + " after");
        for (int i = 0; i < chatHistory[channel].Count; ++i)
        {
            gameObject.GetComponent<TextMesh>().text += chatHistory[channel][i];
        }
    }
}
