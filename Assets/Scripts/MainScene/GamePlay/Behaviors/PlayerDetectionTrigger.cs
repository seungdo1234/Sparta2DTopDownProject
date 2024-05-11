using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NPC ��ȣ�ۿ� ���� �÷��̾� Ž�� Ŭ����
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

    private void OnTriggerEnter2D(Collider2D collision) // NPC ��ȣ�ۿ� Ȱ��ȭ
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }

        playerInputController.OnInteractEvent += npcDialogueHandler.DialogueEvent;
        StartCoroutine(InteractionIconPositionUpdater());
        interactionIcon.gameObject.SetActive(true);

    }
    private void OnTriggerExit2D(Collider2D collision) // NPC ��ȣ�ۿ� ��Ȱ��ȭ
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
            // ȭ�鳻���� ��ǥ + distance��ŭ ������ ��ġ�� Slider UI�� ��ġ�� ����
            interactionIcon.position = screenPosition + interactionIconPosition;

            yield return null;
        }
    }
}
