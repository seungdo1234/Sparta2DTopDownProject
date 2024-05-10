using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;

    private PlayerInputController playerInputController;

    private void Awake()
    {
        playerInputController = GetComponent<PlayerInputController>();
    }

    public void ChangeName()
    {
         nameText.text = EntityDataManager.Instance.PlayerData.Name;
         playerInputController.ControllLocked(false);
    }

    public void ChangeCharacterClass(int characterNum)
    {
        EntityDataManager.Instance.PlayerData.SetCharacterClass(characterNum);
        playerInputController.ControllLocked(false);
    }
  
}
