using System;
using UnityEngine;

public class TopDownAimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer armRenderer; // 화살 뒤집기
    [SerializeField] private Transform armPivot;
    
    [SerializeField] private SpriteRenderer charactorRenderer; // 에임에따라 캐릭터가 뒤집혀야함

    private TopDownController controller;

    private void Awake()
    {
        controller = GetComponent<TopDownController>();
    }

    private void Start()
    {
        controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 direction)
    {
        RotateArm(direction);
    }

    private void RotateArm(Vector2 direction)
    {
        // 캐릭터에서 몬스터를 바라보는 각도를 구함
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        // 바라본 방향으로 캐릭터 Flip  
        charactorRenderer.flipX = Mathf.Abs(rotZ) > 90f;
        // armRenderer.flipY = charactorRenderer.flipX; // y축도 같이 뒤집음
        
        // z축 회전
        armPivot.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}