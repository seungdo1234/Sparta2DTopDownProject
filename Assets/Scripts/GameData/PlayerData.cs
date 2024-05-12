using System;
using UnityEngine;

public class PlayerData : EntityData
{
    [field: Header("# PlayerData")] 
    [SerializeField] private ECharacterClass characterClass;

    public ECharacterClass CharacterClass => characterClass;

    private void Awake()
    {
        base.entityName = PlayerPrefs.GetString("PlayerName");
        characterClass = (ECharacterClass)PlayerPrefs.GetInt("PlayerClass") + 1;
    }

    public void SetPlayerName(string name)
    {
        base.entityName = name;
    }

    public void SetCharacterClass(int characterClassNum)
    {
        characterClass = (ECharacterClass)characterClassNum + 1;
    }
}