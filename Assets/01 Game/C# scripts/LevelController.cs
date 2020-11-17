using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private CastleMinigameController castleMinigameController;

    private void Start()
    {
        castleMinigameController.OnGameStart += CastleMiniGameActivate;
        castleMinigameController.OnComplete += NextLevel;
    }

    private void CastleMiniGameActivate()
    {
        GameManager.Instance.CameraController.SwitchCameraTo(castleMinigameController.Camera,1f).OnComplete(() =>
        {
            castleMinigameController.PushkaController.enabled = true;
            castleMinigameController.CastleController.StartMinigame();
        });
        GameManager.Instance.Player.enabled = false;
        castleMinigameController.OnComplete += NextLevel;
       
    }
    private void NextLevel()
    {
        castleMinigameController.OnGameStart -= CastleMiniGameActivate;
        castleMinigameController.OnComplete -= NextLevel;
        castleMinigameController.PushkaController.enabled = false;
        GameManager.Instance.Player.enabled = true;
        GameManager.Instance.CameraController.SwitchToPlayerCamera(1f).OnComplete(() =>
        {
            GameManager.Instance.Player.gameObject.transform.DOMove(castleMinigameController.End.position, 0.5f);
        });
    }
}
