using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NPC 상호작용 관련 플레이어 탐지 클래스
public class PlayerDetectionTrigger : MonoBehaviour
{
    private TopDownController controller;
    [SerializeField] private NPCDialogueHandler npcDialogueHandler;
    
    private void Start()
    {
        controller = EntityDataManager.Instance.PlayerData.GetComponent<TopDownController>();
    }

    private void OnTriggerEnter2D(Collider2D collision) // NPC 상호작용 활성화
    {
        if (!collision.CompareTag("Player")) // 플레이어가 아니라면 return
        {
            return;
        }
        
        npcDialogueHandler.InteractionIcon.SetupInteractionIcon(transform);
        controller.OnInteractEvent += npcDialogueHandler.DialogueEvent; // 이벤트 추가
    }
    private void OnTriggerExit2D(Collider2D collision) // NPC 상호작용 비활성화
    {
        if (!collision.CompareTag("Player")) // 플레이어가 아니라면 return
        {
            return;
        }
        
        npcDialogueHandler.InteractionIcon.DisableInteractionIcon();
        controller.OnInteractEvent -= npcDialogueHandler.DialogueEvent; // 이벤트 삭제
    } 

}
