using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCubeContoller : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Rigidbody _rigidbody;
    public Action OnPlayerEnter;

    private Color color = Color.red;
    
    private bool isThisCubeForWin;
    public bool IsThisCubeForWin
    {
        set
        {
            isThisCubeForWin = value;
            if (isThisCubeForWin)
            {
                _renderer.material.color = color;
                //_rigidbody.isKinematic = false;
            }
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Player"))
        {
            if (isThisCubeForWin)
            {
                OnPlayerEnter?.Invoke();
            }
        }
    }
}
