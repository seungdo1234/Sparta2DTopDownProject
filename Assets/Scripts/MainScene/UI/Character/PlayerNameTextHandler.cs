using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// 플레이어 이름 텍스트 변경 클래스
public class PlayerNameTextHandler : MonoBehaviour
{
    private TextMeshProUGUI playerNameText;

    private void Awake()
    {
        playerNameText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        PlayerNameTextUpdate();
    }

    public void PlayerNameTextUpdate()
    {
        playerNameText.text = EntityDataManager.Instance.PlayerData.Name;
    }
}
