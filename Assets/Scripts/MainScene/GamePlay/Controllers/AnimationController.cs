using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    protected Animator anim;
    protected TopDownController controller;

    protected virtual void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        controller = GetComponent<TopDownController>();
    }
}
