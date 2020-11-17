using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleController : MonoBehaviour
{
    [SerializeField] private List<Rigidbody> _rigidbodies = new List<Rigidbody>();

    public List<CastleCubeController> CastleCubeControllers = new List<CastleCubeController>();

    // Start is called before the first frame update
    public void StartMinigame()
    {
        foreach (var rb in _rigidbodies)
        {
            rb.isKinematic = false;
        }
    }
}