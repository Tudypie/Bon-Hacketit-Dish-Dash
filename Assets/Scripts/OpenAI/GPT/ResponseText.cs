using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ChatGPTWrapper {

public class ResponseText : MonoBehaviour
{   
    private TMP_Text TextComponent;

    [SerializeField] private ChatGPTWrapper.ChatGPTConversation chatGPTConversation;

    private void Start()
    {
        TextComponent = GetComponent<TMP_Text>();
    }

    public void SetText(string text)
    {   
        text = chatGPTConversation.lastChatGPTMsg;
        TextComponent.text = text;

        Debug.Log("Last user message: " + chatGPTConversation.lastUserMsg);
    }
}

}

