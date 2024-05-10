using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcData : EntityData
{
    private void Start()
    {
        EntityDataManager.Instance.CreateEntities(this);
    }
}
