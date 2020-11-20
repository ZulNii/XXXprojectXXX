using System;
using System.Collections;
using System.Collections.Generic;
using Bolt;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public CameraController CameraController;
    public LevelController LevelController;
    public PlayerController2 PlayerControllerScript;
    
    //fuck
    public Canvas Canvas;

    //fuck
    public GameObject SceneVariables;
    
    //fuck
    public FlowMachine Player;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    
    //fuck
    public List<GameObject> GetPlayerLifeScoreObjectList()
    {
       return Variables.Scene(gameObject).Get<List<GameObject>>("PlayerLifeScoreObjectList");
    }

    //fuck
    public void UpdateBoltList()
    {
        Variables.Scene(gameObject).Set("PlayerLifeScoreObjectList",GetPlayerLifeScoreObjectList());
    }
}
