using System.Collections;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class NPCDialogueHandler : MonoBehaviour
{
    [SerializeField] private DialogueData dialogueData; // NPC 대화 정보
    [SerializeField] private DialogueTextTypingHandler dialogueTextTypingHandler; // 대화 창
    [SerializeField] private DialougeIconPositionUpdateHandler interactionIcon; // 상호작용 아이콘 UI
    [SerializeField] private CameraZoomHandler cameraZoomHandler; // 카메라 줌

    public DialougeIconPositionUpdateHandler InteractionIcon => interactionIcon;
    private PlayerInputController playerInputController;
    private string currentText;
    private void Start()
    {
        playerInputController = EntityDataManager.Instance.PlayerData.GetComponent<PlayerInputController>();
    }

    public void DialogueEvent()
    {
        if (cameraZoomHandler.IsZoomEventRunning()) // 줌 이벤트가 진행중이라면 대화 이벤트 X
        {
            return;
        }
        
        if (dialogueData.DialogueComplete() && !dialogueTextTypingHandler.IsTyping) // 대화가 끝났는지 확인
        {
            // 끝났다면 줌 아웃, 상호작용 아이콘 표시,대화 종료 및 초기화
            cameraZoomHandler.ZoomOut();
            StartCoroutine(ActivateDialogueIcon(cameraZoomHandler.ZoomLerpTime));
            ControlDialogueInterface(false); 
            dialogueData.ResetDialogue();
            return;
        }
        
        if (!dialogueTextTypingHandler.gameObject.activeSelf) // 대화 창이 켜져있지 않다면 대화 시작
        {
            InteractionIcon.DisableInteractionIcon();
            cameraZoomHandler.ZoomIn();
            ControlDialogueInterface(true);
        }

        if (!dialogueTextTypingHandler.IsTyping) // 대화 타이핑이 끝났다면 다음 대화로
        {
            currentText = dialogueData.GetDialogue();
        }
        dialogueTextTypingHandler.TypingDialogueText(currentText); // 대화 타이핑
    }

    private void ControlDialogueInterface(bool isTrue) 
    {
        playerInputController.SetDialogueState(isTrue); // 상호작용 키를 제외한 나머지 키 입력 제한
        dialogueTextTypingHandler.gameObject.SetActive(isTrue); // 대화 창 활성화/비활성화
    }
    
    private IEnumerator ActivateDialogueIcon(float delayTime) // 줌 아웃이 끝나고 상호작용 아이콘이 표시되어야 함
    {
        yield return new WaitForSeconds(delayTime);
        
        interactionIcon.SetupInteractionIcon(transform);
    }
}