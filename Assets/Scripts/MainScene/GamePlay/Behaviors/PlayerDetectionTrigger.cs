using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NPC 상호작용 관련 플레이어 탐지 클래스
public class PlayerDetectionTrigger : MonoBehaviour
{
    private TopDownController controler;
    [SerializeField] private NpcDialogueHandler npcDialogueHandler;
    [SerializeField] private RectTransform interactionIcon; // 상호 작용 가능 UI
    [SerializeField] private Vector3 interactionIconPosition; // 상호 작용 가능 UI가 표시될 위치 

    private bool isPlayerInside = false; // 플레이어가 범위 안으로 들어왔다면 true
    private void Start()
    {
        controler = EntityDataManager.Instance.PlayerData.GetComponent<TopDownController>();
    }

    private void OnTriggerEnter2D(Collider2D collision) // NPC 상호작용 활성화
    {
        if (!collision.CompareTag("Player")) // 플레이어가 아니라면 return
        {
            return;
        }

        isPlayerInside = true;
        StartCoroutine(InteractionIconPositionUpdater());
        interactionIcon.gameObject.SetActive(true);

        controler.OnInteractEvent += npcDialogueHandler.DialogueEvent;
    }
    private void OnTriggerExit2D(Collider2D collision) // NPC 상호작용 비활성화
    {
        if (!collision.CompareTag("Player")) // 플레이어가 아니라면 return
        {
            return;
        }

        isPlayerInside = false;
        interactionIcon.gameObject.SetActive(false);
        controler.OnInteractEvent -= npcDialogueHandler.DialogueEvent;
    }

    private IEnumerator InteractionIconPositionUpdater() // 상호작용 UI 위치를 NPC 옆에 표시
    {
        while (isPlayerInside)
        {
            // Canvas 상에서 NPC의 위치를 구함
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            // 상호 작용 아이콘을 NPC 옆으로 이동
            interactionIcon.position = screenPosition + interactionIconPosition;

            yield return null;
        }
    }
}
