using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class DialogueData 
{
     private int dialogueStep = 0;
    public string[] dialogues;

    public string GetDialogue()
    {
        if(dialogues.Length <= dialogueStep)
        {
            return ".....";
        }

        return dialogues[dialogueStep++];
    }

    public void ResetDialogue()
    {
        dialogueStep = 0;
    }

    public bool DialogueComplete()
    {
        return dialogues.Length <= dialogueStep;
    }
}
