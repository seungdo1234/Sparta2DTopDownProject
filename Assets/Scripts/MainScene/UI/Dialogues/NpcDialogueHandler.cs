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
        if (dialogueData.DialogueComplete())
        {
            ControlDialogueInterface(false);
            dialogueData.ResetDialogue();
            return;
        }
        
        if (!dialogueTextInputHandler.gameObject.activeSelf)
        {
            ControlDialogueInterface(true);
        }

        dialogueTextInputHandler.SetDialogueText(dialogueData.GetDialogue());
    }

    private void ControlDialogueInterface(bool isTrue)
    {
        playerInputController.SetDialogueState(isTrue);
        dialogueTextInputHandler.gameObject.SetActive(isTrue);
    }
}