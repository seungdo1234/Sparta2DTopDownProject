using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialougeIconPositionUpdateHandler : MonoBehaviour
{
    [SerializeField] private Vector3 interactionIconPosition; // 상호 작용 가능 UI가 표시될 위치
    private RectTransform rect;
    private bool isPlayerInside;
    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    public void SetupInteractionIcon(Transform target)
    {
        gameObject.SetActive(true);
        isPlayerInside = true;
        StartCoroutine(PositionUpdateCoroutine(target));
    }

    public void DisableInteractionIcon()
    {
        isPlayerInside = false;
        gameObject.SetActive(false);
    }
    private IEnumerator PositionUpdateCoroutine(Transform target) // 상호작용 UI 위치를 NPC 옆에 표시
    {
        while (isPlayerInside)
        {
            // Canvas 상에서 NPC의 위치를 구함
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(target.position);
            // 상호 작용 아이콘을 NPC 옆으로 이동
            rect.position = screenPosition + interactionIconPosition;

            yield return null;
        }
    }
}