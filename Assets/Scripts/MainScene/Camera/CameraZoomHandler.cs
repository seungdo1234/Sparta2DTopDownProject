using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraZoomHandler : TopDownCameraController
{
    private float baseOrthoSize;
    [SerializeField] private float zoomOrthoSize;
    [SerializeField] private float zoomLerpTime;
    
    
    protected override void Start()
    {
        base.Start();
        baseOrthoSize = mainCamera.m_Lens.OrthographicSize;
    }

    public void ZoomIn()
    {
        StartCoroutine(CameraZoomCoroutine(baseOrthoSize, zoomOrthoSize));
    }

    public void ZoomOut()
    {
        StartCoroutine(CameraZoomCoroutine(zoomOrthoSize, baseOrthoSize));
    }
    private IEnumerator CameraZoomCoroutine(float start, float end)
    {
        float currentTime = 0f;

        while (currentTime < zoomLerpTime)
        {
            currentTime += Time.deltaTime;

            float orthoSize = Mathf.Lerp(start, end, currentTime / zoomLerpTime);
            mainCamera.m_Lens.OrthographicSize = orthoSize;
            yield return null;
        }
    }

}