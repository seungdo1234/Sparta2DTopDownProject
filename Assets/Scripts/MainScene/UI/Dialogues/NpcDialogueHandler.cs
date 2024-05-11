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
            dialogueData.ResetDialogue();
            playerInputController.DialogueOn(false);
            playerInputController.OnInteractEvent -= DialogueEvent;
            dialogueTextInputHandler.gameObject.SetActive(false);
            return;
        }

        
        dialogueTextInputHandler.gameObject.SetActive(true);
        playerInputController.DialogueOn(true);

        dialogueTextInputHandler.SetDialogueText(dialogueData.GetDialogue());
    }
}
