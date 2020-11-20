using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CastleControllerTwo : CastleController
{
    [SerializeField] private List<CastleCubeController> TNTCubes = new List<CastleCubeController>();
    [SerializeField] private List<CastleCubeController> allCubesControllers = new List<CastleCubeController>();
    [SerializeField] private  List<CastleCubeController> cubesForTNT = new List<CastleCubeController>();
    

    // Start is called before the first frame update
    private void Start()
    {
        SetRandomTNTCube();
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

    private void SetRandomTNTCube()
    {
        var randomFrontCube = cubesForTNT[Random.Range(0, cubesForTNT.Count)];
        var castleCubeController = randomFrontCube.GetComponent<CastleCubeController>();
        castleCubeController.IsTnt = true;
        TNTCubes.Add(castleCubeController);
        TNTCubesCount++;
    }

  

    private void SubscribeOnTNTCubes()
    {
        foreach (var tnt in TNTCubes)
        {
            tnt.OnComplete += () =>
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
