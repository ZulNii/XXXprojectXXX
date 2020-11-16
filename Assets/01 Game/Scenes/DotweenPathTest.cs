using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DotweenPathTest : MonoBehaviour
{
    [SerializeField] private Vector3[] wayPoints;
    private void Start()
    {
        transform.DOPath(wayPoints, 5, PathType.Linear, PathMode.Full3D, 10, Color.blue);
    }
}
