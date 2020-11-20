using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    private bool isTriggered;

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player") && !isTriggered)
        {
            transform.tag = "Untagged";
        }
    }
}