using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTriggerController : MonoBehaviour
{
    public Action OnPlayerEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnPlayerEnter?.Invoke();
        }
    }
}
