using UnityEngine;
using TMPro;

public class DialogueTextInputHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;


    private void OnEnable()
    {
        
    }

    public void SetDialogueText(string text)
    {
        dialogueText.text = text;
    }
}   