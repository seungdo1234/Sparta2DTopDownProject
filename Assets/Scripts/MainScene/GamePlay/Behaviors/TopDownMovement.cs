using System;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownController controller;
    private Rigidbody2D rigid;
    private TopDownAnimationController topDownAnimationController;
    
    private Vector2 movementDir = Vector2.zero;
    private void Awake()
    {
        controller = GetComponent<TopDownController>();
        rigid = GetComponent<Rigidbody2D>();
        topDownAnimationController = GetComponent<TopDownAnimationController>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 dir)
    {
        movementDir = dir;
    }
    
    private void ApplyMovement(Vector2 dir) // 실제로 이동을 하는 함수
    {
        // 스탯 적용
        dir *= 5;

        rigid.velocity = dir;
    }

    public void ResetVelocity() // 플레이어 움직임이 제한될 때 호출
    {
        movementDir = Vector2.zero;
        rigid.velocity = Vector2.zero;
        topDownAnimationController.SetAnimatorBool(topDownAnimationController.isRunning , false);
    }
    private void FixedUpdate()
    {
        ApplyMovement(movementDir);
    }
}