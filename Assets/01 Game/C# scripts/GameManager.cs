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

    //fuck
    public GameObject SceneVariables;
    
    //fuck
    public FlowMachine Player;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public List<GameObject> GetPlayerLifeScoreObjectList()
    {
       return Variables.Scene(gameObject).Get<List<GameObject>>("PlayerLifeScoreObjectList");
    }

    public void UpdateBoltList()
    {
        Variables.Scene(gameObject).Set("PlayerLifeScoreObjectList",GetPlayerLifeScoreObjectList());
    }
}
