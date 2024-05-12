using UnityEngine;

public class NpcDialogueHandler : MonoBehaviour
{
    [SerializeField] private DialogueData dialogueData;
    [SerializeField] private DialogueTextInputHandler dialogueTextInputHandler;

    private PlayerInputController playerInputController;


    private void Start()
    {
        playerInputController = EntityDataManager.Instance.PlayerData.GetComponent<PlayerInputController>();

        // 대화에 '@'가 있다면 플레이어 이름으로 치환
        for (int i = 0; i < dialogueData.dialogues.Length; i++) 
        {
            int idx = dialogueData.dialogues[i].IndexOf("\'@\'");
            if (idx >= 0)
            {
                string playerName = EntityDataManager.Instance.PlayerData.Name;
                dialogueData.dialogues[i] = dialogueData.dialogues[i].Replace("\'@\'", $"\'{playerName}\'");
                Debug.Log(dialogueData.dialogues[i]);
            }
        }
    }

    public void DialogueEvent()
    {
        if (dialogueData.DialogueComplete()) // 대화가 끝났는지 확인
        {
            // 끝났다면 대화 종료 및 초기화
            ControlDialogueInterface(false); 
            dialogueData.ResetDialogue();
            return;
        }
        
        if (!dialogueTextInputHandler.gameObject.activeSelf) // 대화 창이 켜져있지 않다면 대화 시작
        {
            ControlDialogueInterface(true);
        }

        // 대화 창 텍스트에 대화 저장
        dialogueTextInputHandler.SetDialogueText(dialogueData.GetDialogue());
    }

    private void ControlDialogueInterface(bool isTrue) // 대화 창 활성화/비활성화
    {
        playerInputController.SetDialogueState(isTrue);
        dialogueTextInputHandler.gameObject.SetActive(isTrue);
    }
}