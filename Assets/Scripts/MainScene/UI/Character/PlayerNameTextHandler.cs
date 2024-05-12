using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// 플레이어 이름 텍스트 변경 클래스
public class PlayerNameTextHandler : MonoBehaviour
{
    private TextMeshProUGUI playerNameText;
    private RectTransform rect;
    private void Awake()
    {
        playerNameText = GetComponentInChildren<TextMeshProUGUI>();
        rect = GetComponent<RectTransform>();
    }

    private void Start()
    {
        PlayerNameTextUpdate();
    }

    public void PlayerNameTextUpdate() // 닉네임 업데이트
    {
        playerNameText.text = EntityDataManager.Instance.PlayerData.Name;
        // 닉네임 길이에 맞게 배경 이미지 크기 조절
        rect.sizeDelta = new Vector2(playerNameText.preferredWidth + 0.3f, rect.sizeDelta.y);
    }
}
