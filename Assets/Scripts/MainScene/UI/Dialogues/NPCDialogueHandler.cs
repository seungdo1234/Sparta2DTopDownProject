using UnityEngine;
using UnityEngine.Serialization;

public class NPCDialogueHandler : MonoBehaviour
{
    [SerializeField] private DialogueData dialogueData; // NPC 대화 정보
    [SerializeField] private DialogueTextTypingHandler dialogueTextTypingHandler; // 대화 창

    private PlayerInputController playerInputController;
    private string currentText;
    private void Start()
    {
        playerInputController = EntityDataManager.Instance.PlayerData.GetComponent<PlayerInputController>();
    }

    public void DialogueEvent()
    {
        if (dialogueData.DialogueComplete() && !dialogueTextTypingHandler.IsTyping) // 대화가 끝났는지 확인
        {
            // 끝났다면 대화 종료 및 초기화
            ControlDialogueInterface(false); 
            dialogueData.ResetDialogue();
            return;
        }
        
        if (!dialogueTextTypingHandler.gameObject.activeSelf) // 대화 창이 켜져있지 않다면 대화 시작
        {
            ControlDialogueInterface(true);
        }

        if (!dialogueTextTypingHandler.IsTyping) // 타이핑 하고 있지 않다면 다음 대화로
        {
            currentText = dialogueData.GetDialogue();
        }
        dialogueTextTypingHandler.TypingDialogueText(currentText);
    }

    private void ControlDialogueInterface(bool isTrue) // 대화 창 활성화/비활성화
    {
        playerInputController.SetDialogueState(isTrue);
        dialogueTextTypingHandler.gameObject.SetActive(isTrue);
    }
}