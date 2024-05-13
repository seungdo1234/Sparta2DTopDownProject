using System.Collections;
using UnityEngine;

public class CameraZoomHandler : TopDownCameraController
{

    [SerializeField] private float zoomOrthoSize;
    [SerializeField] private float zoomLerpTime;
    private float baseOrthoSize;
    private float currentTime = float.MaxValue;

    private Coroutine zoomEventCoroutine;
    public float ZoomLerpTime => zoomLerpTime;
    protected override void Start()
    {
        base.Start();
        baseOrthoSize = mainCamera.m_Lens.OrthographicSize;
    }

    public void ZoomIn()
    {
        if (zoomEventCoroutine != null)
            StopCoroutine(zoomEventCoroutine);
        
        zoomEventCoroutine = StartCoroutine(CameraZoomCoroutine(baseOrthoSize, zoomOrthoSize));

    }

    public void ZoomOut()
    {
        if (zoomEventCoroutine != null)
            StopCoroutine(zoomEventCoroutine);
        
        zoomEventCoroutine = StartCoroutine(CameraZoomCoroutine(zoomOrthoSize, baseOrthoSize));
    }

    public bool IsZoomEventRunning()
    {
        return currentTime < zoomLerpTime;
    }
    
    private IEnumerator CameraZoomCoroutine(float start, float end)
    {
        currentTime = 0f;

        while (currentTime < zoomLerpTime)
        {
            currentTime += Time.deltaTime;

            float orthoSize = Mathf.Lerp(start, end, currentTime / zoomLerpTime);
            mainCamera.m_Lens.OrthographicSize = orthoSize;
            yield return null;
        }
    }

}