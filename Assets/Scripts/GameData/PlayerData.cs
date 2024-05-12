using System;
using UnityEngine;

public class PlayerData : EntityData
{
    [field:SerializeField]public ECharacterClass CharacterClass { get; private set; }

    private void Awake()
    {
        Name = PlayerPrefs.GetString("PlayerName");
        CharacterClass = (ECharacterClass)PlayerPrefs.GetInt("PlayerClass") + 1;
    }

    public void SetPlayerName(string name)
    {
        Name = name;
    }

    public void SetCharacterClass(int characterClassNum)
    {
        CharacterClass = (ECharacterClass)characterClassNum + 1;
    }
}