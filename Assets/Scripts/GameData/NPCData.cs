using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCData : EntityData
{
    private void Start()
    {
        EntityDataManager.Instance.CreateNPCs(this);
    }
}
