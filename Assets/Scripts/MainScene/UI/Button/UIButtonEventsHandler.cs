using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonEventsHandler : MonoBehaviour //  UI 버튼 이벤트들을 다루는 클래스
{
    [SerializeField] private TextInputHandler textInputHandler;
    [SerializeField] private GameObject CharacterClassChangeUI;
    [SerializeField] private UserViewHandler userViewHandler;
    [SerializeField] private PlayerNameTextHandler playerNameTextHandler;
    private PlayerInputController playerInputController;
    private TopDownAnimationController topDownAnimationController;
    private void Start()
    {
        playerInputController = EntityDataManager.Instance.PlayerData.GetComponent<PlayerInputController>();
        topDownAnimationController = EntityDataManager.Instance.PlayerData.GetComponent<TopDownAnimationController>();
    }


    public void ChangePlayerNameInGame()
    {
        EntityDataManager.Instance.PlayerData.SetPlayerName(textInputHandler.NameText);
        userViewHandler.UpdateUserName();
        playerNameTextHandler.PlayerNameTextUpdate();
        ActivateNameChangeEventWindow(false);
    }
    public void ActivateNameChangeEventWindow(bool isTrue)
    {
        playerInputController.ControlLocked(isTrue);
        textInputHandler.gameObject.SetActive(isTrue);
    }
    
    public void ChangePlayerClassInGame(int characterNum)
    {
        EntityDataManager.Instance.PlayerData.SetCharacterClass(characterNum);
        topDownAnimationController.ChangeCharacter();
        ActivateClassChangeEventWindow(false);
    }
    public void ActivateClassChangeEventWindow(bool isTrue)
    {
        playerInputController.ControlLocked(isTrue);
        CharacterClassChangeUI.gameObject.SetActive(isTrue);
    }
    
    public void ActivateUserViewEventWindow(bool isTrue)
    {
        userViewHandler.gameObject.SetActive(isTrue);
    }
    
}
