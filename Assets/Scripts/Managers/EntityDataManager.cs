using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityDataManager : MonoBehaviour
{
    public static EntityDataManager Instance;

    [field:SerializeField] public PlayerData PlayerData { get; private set; }
    public List<NPCData> NPCList { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            NPCList = new List<NPCData>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CreateNPCs(NPCData entityData) // 존재하는 NPC 정보를 NPC 리스트에 넣음
    {
        NPCList.Add(entityData);
    }
    
}
