using UnityEngine;

public class PlayerData : EntityData
{
    [field:SerializeField]public ECharacterClass CharacterClass { get; private set; }
    
    public void SetPlayerName(string name)
    {
        Name = name;
    }

    public void SetCharacterClass(int characterClassNum)
    {
        CharacterClass = (ECharacterClass)characterClassNum + 1;
    }
}