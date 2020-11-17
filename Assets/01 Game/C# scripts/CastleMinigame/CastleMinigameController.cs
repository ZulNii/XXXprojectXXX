using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CastleMinigameController : MonoBehaviour
{
    public CastleController CastleController;
    public PushkaController PushkaController;
    public FinishTriggerController FinishTriggerController;
    public Transform Start, End;
    public CinemachineVirtualCamera Camera;

    private void Awake()
    {
        FinishTriggerController.OnPlayerEnter += () => OnGameStart?.Invoke();
        foreach (var ccc in CastleController.CastleCubeControllers)
        {
            ccc.OnComplete += () =>
            {
                var cubesCount = CastleController.CastleCubeControllers.Count;
                float score = 300f / cubesCount;
                Debug.Log(score);
                Progress += score;
            };
        }
    }

    public Action OnGameStart;
    public Action OnComplete;

    private float progress;

    public float Progress
    {
        get => progress;
        set
        {
            progress = value;
            Debug.Log($"castle progress {progress}/100");
            if (progress >= 40)
            {
                OnComplete?.Invoke();
                Destroy(CastleController.gameObject);
            }
        }
    }
}