using UnityEngine;

public class NpcDialogueHandler : MonoBehaviour
{
    [SerializeField] private DialogueData dialogueData;
    [SerializeField] private DialogueTextInputHandler dialogueTextInputHandler;

    private PlayerInputController playerInputController;

    private void Start()
    {
        playerInputController = EntityDataManager.Instance.PlayerData.GetComponent<PlayerInputController>();
    }

    public void DialogueEvent()
    {
        if (dialogueData.DialogueComplete())
        {
            DialogueEnd();
            return;
        }
        
        if (!dialogueTextInputHandler.gameObject.activeSelf)
        {
            dialogueTextInputHandler.gameObject.SetActive(true);
            playerInputController.SetDialogueState(true);
        }

        dialogueTextInputHandler.SetDialogueText(dialogueData.GetDialogue());
    }

    private void DialogueEnd()
    {
        dialogueData.ResetDialogue();
        playerInputController.SetDialogueState(false);
        dialogueTextInputHandler.gameObject.SetActive(false);
    }
}