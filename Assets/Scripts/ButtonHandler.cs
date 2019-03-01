using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HoloToolkit.UI.Keyboard;

public class ButtonHandler : MonoBehaviour
{
    public GameObject chatHistoryText;

    public void sendButtonClicked()
    {
        string textInput = GetComponent<KeyboardInputField>().text;
        Debug.Log(textInput);
        GetComponent<KeyboardInputField>().text = "";
        // chatHistoryText.GetComponent<TextMesh>().text += ("Myself: " + textInput + "\n");
        for (int i = 50; i < textInput.Length; i += 50)
        {
            textInput = textInput.Substring(0, i) + "\n" + textInput.Substring(i);
        }
        string fullText = "Myself" + ": " + textInput + "\n";
        if (chatHistoryText.active)
        {
            chatHistoryText.GetComponent<ChatMessages>().updateText(VideoControllerNew.instance.cur_vid_index, fullText);
        }
        ChatHistoryStorage.Instance.chatMessages[VideoControllerNew.instance.cur_vid_index].Add(fullText);
        SharingAPI.Instance.BroadcastInformation(SharingAPI.commandType.sendChatMessage, VideoControllerNew.instance.cur_vid_index, textInput);
    }
}
