using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity;
using UnityEngine;

public class ChatHistoryStorage : Singleton<ChatHistoryStorage> {
    public Dictionary<int, List<string>> chatMessages;

    // Use this for initialization
    public void instantiateDictionary () {
        chatMessages = new Dictionary<int, List<string>>();
        for (int i = 0; i < VideoControllerNew.instance.videos.Length; ++i)
        {
            Debug.Log("i is :" + i);
            chatMessages.Add(i, new List<string>());
        }
        Debug.Log("[!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!] ");
    }
	
}
