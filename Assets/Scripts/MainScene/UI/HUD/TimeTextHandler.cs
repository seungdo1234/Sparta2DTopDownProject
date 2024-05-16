using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class TimeTextHandler : MonoBehaviour
{
    private TextMeshProUGUI timeText;
    
    private void Awake()
    {
        timeText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        StartCoroutine(UpdateTimeText());
    }

    private IEnumerator UpdateTimeText() // 시간 업데이트 코루틴
    {
        while (true)
        {
            DateTime now = DateTime.Now;
            timeText.text = $"{now:HH:mm}";

            float waitTime =  60 - now.Second; // 남은 초를 계산하여 기다림
            yield return new WaitForSeconds(waitTime);
        }
    }
    
    
    
}
