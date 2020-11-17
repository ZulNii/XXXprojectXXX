using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject castle;
    [SerializeField] private GameObject startFloorPrefab;
    private CastleMinigameController castleMinigameController;

    public GameObject Castle
    {
        get
        {
            return castle;
        }
        set
        {
            castle = value;
            castleMinigameController = castle.GetComponent<CastleMinigameController>();
            castleMinigameController.OnGameStart += CastleMiniGameActivate;
            //castleMinigameController.OnComplete += NextLevel;
        }
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

        var previousEndPoint = castleMinigameController.End;
        var endCastlePoint = castleMinigameController.End;
        var startFloor = Instantiate(startFloorPrefab);
        var startFloorStartPoint = startFloor.transform.GetChild(1);
        startFloor.transform.position = endCastlePoint.position;
        
        var distance = Vector3.Distance(startFloorStartPoint.position, endCastlePoint.position);
        startFloor.transform.position += new Vector3(0,0,distance);
        
        
        castleMinigameController.PushkaController.enabled = false;
        GameManager.Instance.Player.enabled = true;
        GameManager.Instance.CameraController.SwitchToPlayerCamera(1f).OnComplete(() =>
        {
            GameManager.Instance.Player.gameObject.transform.DOMoveX(previousEndPoint.position.x, 0.5f);
            GameManager.Instance.Player.gameObject.transform.DOMoveZ(previousEndPoint.position.z, 0.5f);
        });
    }
}
