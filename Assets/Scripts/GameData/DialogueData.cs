[System.Serializable]
public class DialogueData 
{
    private int dialogueStep = 0; // ��ȭ �ܰ� 
    public string[] dialogues; // �ܰ躰 ��ȭ�� �����ϴ� ���ڿ� �迭

    public string GetDialogue() // ��ȭ ��ȯ
    {
        if(dialogues.Length <= dialogueStep)
        {
            return ".....";
        }

        return dialogues[dialogueStep++];
    }

    public void ResetDialogue() // ��ȭ �ܰ� �ʱ�ȭ
    {
        dialogueStep = 0;
    }

    public bool DialogueComplete() // ��ȭ�� ������ �� ��ȯ
    {
        return dialogues.Length <= dialogueStep;
    }
}
