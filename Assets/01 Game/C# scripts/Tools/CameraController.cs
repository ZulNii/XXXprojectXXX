using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Action OnTransitionEnd;
    [SerializeField] private CinemachineVirtualCamera playerCamera;
    [SerializeField] private CinemachineBrain cinemachineBrain;
    private const float defaultTransitionTime = 2f;

    //for debug
    [SerializeField] private CinemachineVirtualCamera currentCamera;

    
    public Tween SwitchToPlayerCamera(float transitionTime)
    {
        return SwitchCameraTo(playerCamera, transitionTime);
    }
    
    public Tween SwitchCameraTo(CinemachineVirtualCamera camera, float transitionTime)
    {
        cinemachineBrain.m_DefaultBlend.m_Time = transitionTime;
        currentCamera.Priority = 0;
        currentCamera = camera;
        currentCamera.Priority = 1;

        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(transitionTime);
        return sequence.AppendCallback(() =>
        {
            OnTransitionEnd?.Invoke();
            cinemachineBrain.m_DefaultBlend.m_Time = defaultTransitionTime;
        });
    }
}