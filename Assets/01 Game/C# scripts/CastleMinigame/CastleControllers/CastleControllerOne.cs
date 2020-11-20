using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CastleControllerOne : CastleController
{
    [SerializeField] private List<CastleCubeController> TNTCubes = new List<CastleCubeController>();
    [SerializeField] private List<CastleCubeController> allCubesControllers = new List<CastleCubeController>();
    [SerializeField] private List<GameObject> leftFrontCubes = new List<GameObject>();
    [SerializeField] private List<GameObject> rightFrontCubes = new List<GameObject>();
    
    // Start is called before the first frame update
    private void Start()
    {
        SetLeftTNT();
        SetRightTNT();
        SubscribeOnTNTCubes();
    }
    public override void StartMinigame()
    {
        foreach (var cubeController in allCubesControllers)
        {
            if(cubeController.IsTnt) continue;
            cubeController.Rb.isKinematic = false;
        }
    }

    private void SetLeftTNT()
    {
        var randomFrontCube = leftFrontCubes[Random.Range(0, leftFrontCubes.Count)];
        var castleCubeController = randomFrontCube.GetComponent<CastleCubeController>();
        castleCubeController.IsTnt = true;
        TNTCubes.Add(castleCubeController);
        TNTCubesCount++;
    }

    private void SetRightTNT()
    {
        var randomFrontCube = rightFrontCubes[Random.Range(0, rightFrontCubes.Count)];
        var castleCubeController = randomFrontCube.GetComponent<CastleCubeController>();
        castleCubeController.IsTnt = true;
        TNTCubes.Add(castleCubeController);
        TNTCubesCount++;
    }

    private void SubscribeOnTNTCubes()
    {
        foreach (var TNTCube in TNTCubes)
        {
            TNTCube.OnComplete += () =>
            {
                progress++;
                if (progress >= TNTCubesCount)
                {
                    OnCompleteGame();
                }
            };
        }
    }
}
