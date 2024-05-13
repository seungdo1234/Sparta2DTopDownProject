using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterClassSelect : MonoBehaviour
{
    private int characterNum;
    [SerializeField] private Sprite[] characterSprites;
    [SerializeField] private Image selectCharacterImage;
    public void Select(int num)
    {
        characterNum = num;

        selectCharacterImage.sprite = characterSprites[characterNum];
    }

    // StartScene JoinBtn OnClick
    public void DicideCharacterClassInLogin()
    {
        PlayerPrefs.SetInt("PlayerClass",characterNum);
    }

}
