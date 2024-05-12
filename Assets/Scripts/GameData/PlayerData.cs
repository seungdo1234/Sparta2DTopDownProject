using System;
using UnityEngine;

public class PlayerData : EntityData
{
    [field: Header("# PlayerData")] 
    [SerializeField] private ECharacterClass characterClass;

    public ECharacterClass CharacterClass => characterClass;

    private void Awake()
    {
        // StartScene에서 저장한 이름과 직업을 불러옴
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