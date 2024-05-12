using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueTextTypingHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private float typingSpeed;

    public bool IsTyping { get; private set; }
    private WaitForSeconds wait;
    private void Awake()
    {
        wait = new WaitForSeconds(typingSpeed);
    }

    public void TypingDialogueText(string text)
    {
        string playerName = EntityDataManager.Instance.PlayerData.Name;
        text = text.Replace("\'@\'", $"\'{playerName}\'");
        
        if (!IsTyping)
        {
            dialogueText.text = "";
            IsTyping = true;
            StartCoroutine(TextTyping(text));
        }
        else
        {
            IsTyping = false;
            dialogueText.text = text;
        }
    }

    private IEnumerator TextTyping(string text) // 타이핑
    {
        int typingCount = 0;
        while (IsTyping && typingCount < text.Length)
        {
            dialogueText.text += text[typingCount];
            typingCount++;
            yield return wait;
        }
    }
}   