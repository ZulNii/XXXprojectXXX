using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class BrickTrapController : TrapController
{
    [SerializeField] private List<WallCubeContoller> _lowerCubeContollers = new List<WallCubeContoller>();
    [SerializeField] private List<WallCubeContoller> allCubesContollers = new List<WallCubeContoller>();
    [SerializeField] private List<Rigidbody> _rigidbodies = new List<Rigidbody>();

    //fuck
    private bool isTriggered;

    void Awake()
    {
        SetRandomWinCube();
        SubScribe();
    }
    
    private void SetRandomWinCube()
    {
        var randomCube = _lowerCubeContollers[Random.Range(0, _lowerCubeContollers.Count)];
        randomCube.IsThisCubeForWin = true;
    }

    private void CreateBoom()
    {
        if (!isTriggered)
        {
            foreach (var _rb in _rigidbodies)
            {
                _rb.isKinematic = false;
                _rb.tag = "Untagged";
            }

            OnTrapDestroy?.Invoke(gameObject);
            isTriggered = true;
            Destroy(gameObject, 3f);
        }
    }

    private void SubScribe()
    {
        foreach (var lowerCubeContoller in _lowerCubeContollers)
        {
            lowerCubeContoller.OnPlayerEnter += CreateBoom;
        }
    }
}