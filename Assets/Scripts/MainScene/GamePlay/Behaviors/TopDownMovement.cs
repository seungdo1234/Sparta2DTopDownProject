using System;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownController controller;
    private Rigidbody2D rigid;

    private Vector2 movementDir = Vector2.zero;
    private void Awake()
    {
        controller = GetComponent<TopDownController>();
        rigid = GetComponent<Rigidbody2D>();
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

    private void FixedUpdate()
    {
        ApplyMovement(movementDir);
    }
}