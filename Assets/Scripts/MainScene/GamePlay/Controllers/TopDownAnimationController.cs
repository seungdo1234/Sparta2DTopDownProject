
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownAnimationController : AnimationController
{
    public readonly int isRunning = Animator.StringToHash("isRunning");
    public readonly int isHit = Animator.StringToHash("isHit");

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
        anim.SetBool(isRunning, direction != Vector2.zero);
    }
    private void Hit()
    {
        anim.SetBool(isHit, true);
    }
    public void SetAnimatorBool(int id, bool isTrue)
    {
        anim.SetBool(id, isTrue);
    }
}
