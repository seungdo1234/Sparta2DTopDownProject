using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityDataManager : MonoBehaviour
{
    public static EntityDataManager Instance;

    [field:SerializeField] public PlayerData PlayerData { get; private set; }
    public List<EntityData> Entities { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Entities = new List<EntityData>();
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CreateEntities(EntityData entityData)
    {
        Entities.Add(entityData);
    }
    
}
