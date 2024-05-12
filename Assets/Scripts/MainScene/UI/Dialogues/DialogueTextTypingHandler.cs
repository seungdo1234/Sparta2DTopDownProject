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
        // text에 '@'가 존재한다면 플레이어 이름으로 치환
        string playerName = EntityDataManager.Instance.PlayerData.Name;
        text = text.Replace("\'@\'", $"\'{playerName}\'");
        
        if (!IsTyping) // 타이핑 시작
        {
            dialogueText.text = "";
            IsTyping = true;
            StartCoroutine(TextTyping(text));
        }
        else // 타이핑 중일 땐 전체 완성
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
        IsTyping = false;
    }
}   