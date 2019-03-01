using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity;
using HoloToolkit.Sharing;
using UnityEngine;


public class SharingAPI : Singleton<SharingAPI>
{
    // Total number of possible item prefabs
    int NumItemTypes;
    public string userName;
    public GameObject chatHistoryText;
    // TODO: Add code here to load prefabs like what Alex did in the other script
    // or try to call some functions inside other scripts whenever a message is received.

    public enum commandType
    {
        sendChatMessage
    }

    //int lowerFrame = 0;

    // Use this for initialization
    void Start()
    {
        CustomMessages.Instance.MessageHandlers[CustomMessages.TestMessageID.chatMessage] = this.OnChatMessageReceived;
    }

    #region BroadcastMessageFunctions

    // Called when we need to broadcast information to Other HoloLens and Server
    public void BroadcastInformation(commandType command, int channel, string msg)
    {
        // Broadcast the information to other users 
        Debug.Log("Broadcasting message: " + userName + " " + command + " " + msg);
        CustomMessages.Instance.SendMessageOperation(new MessageIO(userName, (int)command, channel, msg));
    }

    #endregion BroadcastMessageFunctions

    #region ReceiveMessageFunctions

    public void OnChatMessageReceived(NetworkInMessage msg)
    {
        //read user id etc of the front of the message
        msg.ReadInt32();
        msg.ReadInt32();

        MessageIO msg_received = new MessageIO(
            msg.ReadString(),
            msg.ReadInt32(),
            msg.ReadInt32(),
            msg.ReadString()
        );

        Debug.Log("Recieved a message with command " + msg_received.operation);

        switch (msg_received.operation)
        {
            case (int)commandType.sendChatMessage:
                string fullText = msg_received.user_name + ": " + msg_received.chat_message + "\n";
                if (chatHistoryText.active)
                {
                    chatHistoryText.GetComponent<ChatMessages>().updateText(msg_received.channel, fullText);
                }
                ChatHistoryStorage.Instance.chatMessages[msg_received.channel].Add(fullText);
                break;
        }
    }

    #endregion ReceiveMessageMovement
}


public class MessageIO
{
    // Add object to backpack; Remove object from backpack; Place the object at start up (position info)
    public string user_name;
    public int channel;
    public int operation;
    public string chat_message;

    public MessageIO(string usr_name, int op, int chan, string chat_msg)
    {
        user_name = usr_name;
        operation = op;
        channel = chan;
        chat_message = chat_msg;
    }
}