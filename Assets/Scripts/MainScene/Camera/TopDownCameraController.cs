using System;
using Cinemachine;
using UnityEngine;

public class TopDownCameraController : MonoBehaviour
{
    protected CinemachineVirtualCamera mainCamera;
    private void Awake()
    {
        mainCamera = GetComponent<CinemachineVirtualCamera>();
    }

    protected virtual void Start()
    {
    }
}