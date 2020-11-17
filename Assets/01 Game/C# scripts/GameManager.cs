using System;
using System.Collections;
using System.Collections.Generic;
using Bolt;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerController PlayerController;
    public CameraController CameraController;
    public LevelController LevelController;
    //public Transform Player;
    public FlowMachine Player;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
}
