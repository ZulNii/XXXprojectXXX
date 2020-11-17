using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CastleCubeController : MonoBehaviour
{
    [SerializeField] private Vector3 defaultPosition;
    [SerializeField] private Rigidbody _rigidbody;
    private bool isTriggered;
    public Action OnComplete;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.CompareTag("Bullet") &&!isTriggered)
        {
            isTriggered = true;
            _rigidbody.isKinematic = false;
            OnComplete?.Invoke();
        }
    }
}