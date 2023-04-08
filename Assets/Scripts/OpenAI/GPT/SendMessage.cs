using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ChatGPTWrapper {

public class SendMessage : MonoBehaviour
{   
    [SerializeField] TMP_InputField prompt;

    [SerializeField] private ChatGPTWrapper.ChatGPTConversation chatGPTConversation;

    public UnityStringEvent sendToChatGPT = new UnityStringEvent();

    public void SendToChatGPT(string text)
    {
        text = prompt.text;
        
        chatGPTConversation.lastUserMsg = text;

        sendToChatGPT.Invoke(text);
    }
}

}

