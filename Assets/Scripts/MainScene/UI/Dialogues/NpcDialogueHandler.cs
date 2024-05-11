using UnityEngine;

public class NpcDialogueHandler : MonoBehaviour
{
    [SerializeField] private DialogueData dialogueData;
    [SerializeField] private DialogueTextInputHandler dialogueTextInputHandler;

    private TopDownController controller;
    private void Start()
    {
        controller = EntityDataManager.Instance.PlayerData.GetComponent<TopDownController>();
    }
    public void DialogueEvent()
    {
        if (dialogueData.DialogueComplete())
        {
            controller.OnInteractEvent -= DialogueEvent;
            dialogueTextInputHandler.gameObject.SetActive(false);
            return;
        }

        dialogueTextInputHandler.gameObject.SetActive(true);

        dialogueTextInputHandler.SetDialogueText(dialogueData.GetDialogue());
    }
}
