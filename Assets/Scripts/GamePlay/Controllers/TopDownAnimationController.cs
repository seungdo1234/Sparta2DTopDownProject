using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownAnimationController : AnimationController
{
    private static readonly int isWalking = Animator.StringToHash("isRunning");
    private static readonly int isHit = Animator.StringToHash("isHit");
    
    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 direction)
    {
        anim.SetBool(isWalking, direction != Vector2.zero);
    }
    private void Hit()
    {
        anim.SetBool(isHit, true);
    }
}
