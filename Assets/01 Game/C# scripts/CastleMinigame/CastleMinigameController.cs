using System;
using Cinemachine;
using UnityEngine;

public class CastleMinigameController : MonoBehaviour
{
    public CastleController CastleController;
    public PushkaController PushkaController;
    public FinishTriggerController FinishTriggerController;
    public Transform Start, End;
    public CinemachineVirtualCamera Camera;
    
    public Action OnGameStart;
    public Action OnComplete;

    private void Awake()
    {
        FinishTriggerController.OnPlayerEnter += () => OnGameStart?.Invoke();
        CastleController.OnComplete += () => OnComplete?.Invoke();
    }
}