using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserViewHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI UserText;


    private void OnEnable()
    {
        List<EntityData> entities = EntityDataManager.Instance.Entities;
        UserText.text = $"{EntityDataManager.Instance.PlayerData.Name}\n";
        
        for (int i = 0; i < entities.Count; i++)
        {
            UserText.text += $"{entities[i].Name}\n";
        }
    }
}
