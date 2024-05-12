using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EntityData : MonoBehaviour
{
    [Header("# EntityData")] 
    [SerializeField] protected string entityName;
    [SerializeField] protected float moveSpeed;

    public string Name => entityName;
    public float MoveSpeed => moveSpeed;
}