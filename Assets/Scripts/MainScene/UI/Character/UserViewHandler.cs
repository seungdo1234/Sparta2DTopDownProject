using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserViewHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI UserText;


    private void OnEnable() // 참여 사용자 최신화
    {
        List<NPCData> npcList = EntityDataManager.Instance.NPCList;
        UserText.text = $"{EntityDataManager.Instance.PlayerData.Name}\n";
        
        for (int i = 0; i < npcList.Count; i++)
        {
            UserText.text += $"{npcList[i].Name}\n";
        }
    }
}
