using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownController
{
    private Camera camera;

    private bool dialogueStateOn = false; // 대화 창 활성화 표시 bool변수
    private bool IsControlLock = false; // 플레이어 입력을 제한하는 bool변수
    
    private TopDownMovement topDownMovement;
    protected override void Awake()
    {
        base.Awake();
        if (Camera.main != null)
        {
            camera = Camera.main; // mainCamera 태그를 가진 카메라의 정보를 받아옴
        }

        topDownMovement = GetComponent<TopDownMovement>();
    }

    public void OnMove(InputValue value)
    {
        if (IsControlLock)
        {
            return;
        }

        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value)
    {
        if (IsControlLock)
        {
            return;
        }

        // 정규화를 하면 안됨 -> 캐릭터의 위치 기준에서 마우스 위치에 따라 왼쪽 오른쪽을 결정하기 때문에
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToWorldPoint(newAim);
        // 플레이어와 마우스 포인터의 차이를 구한 뒤 정규화(플레이어가 바라볼 방향 구함)
        newAim = (worldPos - (Vector2)transform.position).normalized;

        CallLookEvent(newAim);
    }

    public void OnInteract(InputValue value)
    {
        if (IsControlLock && !dialogueStateOn)
        {
            return;
        }

        if (value.isPressed) // 상호작용 키 누름
        {
            CallInteractEvent();
        }
    }

    public void ControlLocked(bool isTrue)
    {
        IsControlLock = isTrue;
        if (isTrue)
        {
            topDownMovement.ResetVelocity();
        }
    }

    public void SetDialogueState(bool isTrue)
    {
        // 대화 창이 활성화되면 상호작용 입력을 제외한 나머지 플레이어 입력을 제한해야함
        ControlLocked(isTrue);
        dialogueStateOn = isTrue;
    }
    
}