using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NPC 상호작용 관련 플레이어 탐지 클래스
public class PlayerDetectionTrigger : MonoBehaviour
{
    private PlayerInputController playerInputController;
    [SerializeField] private NpcDialogueHandler npcDialogueHandler;
    [SerializeField] private RectTransform interactionIcon;
    [SerializeField] private Vector3 interactionIconPosition;


    private void Awake()
    {
        playerInputController = EntityDataManager.Instance.PlayerData.GetComponent<PlayerInputController>();
    }

    private void OnTriggerEnter2D(Collider2D collision) // NPC 상호작용 활성화
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }

        playerInputController.OnInteractEvent += npcDialogueHandler.DialogueEvent;
        StartCoroutine(InteractionIconPositionUpdater());
        interactionIcon.gameObject.SetActive(true);

    }
    private void OnTriggerExit2D(Collider2D collision) // NPC 상호작용 비활성화
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }

        playerInputController.OnInteractEvent -= npcDialogueHandler.DialogueEvent;
        StopCoroutine(InteractionIconPositionUpdater());
        interactionIcon.gameObject.SetActive(false);
    }

    private IEnumerator InteractionIconPositionUpdater()
    {
        while (true)
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            // 화면내에서 좌표 + distance만큼 떨어진 위치를 Slider UI의 위치로 설정
            interactionIcon.position = screenPosition + interactionIconPosition;

            yield return null;
        }
    }
}
