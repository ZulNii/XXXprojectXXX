using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CastleCubeController : MonoBehaviour
{
    public Rigidbody Rb;
    [SerializeField] private Renderer _renderer;
    private bool isTriggered;
    public Action OnComplete;

    private bool isTNT;

    public bool IsTnt
    {
        get => isTNT;
        set
        {
            isTNT = value;
            if (isTNT)
            {
                _renderer.material.color = Color.red;
            }
        }
    }

    private void Awake()
    {
        Rb = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.CompareTag("Bullet") &&!isTriggered && isTNT)
        {
            isTriggered = true;
            Rb.isKinematic = false;
            transform.DOScale(5, 0.2f);
            _renderer.material.DOColor(Color.green, 0.2f).OnComplete(()=> OnComplete?.Invoke());
        }
    }
}