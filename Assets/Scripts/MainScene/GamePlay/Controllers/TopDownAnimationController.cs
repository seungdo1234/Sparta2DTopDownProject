
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownAnimationController : AnimationController
{
    private static readonly int isWalking = Animator.StringToHash("isRunning");
    private static readonly int isHit = Animator.StringToHash("isHit");

    [SerializeField] private RuntimeAnimatorController[] animatorControllers;
    
    private void Start()
    {
        controller.OnMoveEvent += Move;
        ChangeCharacter();
    }

    public void ChangeCharacter()
    {
        anim.runtimeAnimatorController = animatorControllers[(int)EntityDataManager.Instance.PlayerData.CharacterClass - 1];
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
