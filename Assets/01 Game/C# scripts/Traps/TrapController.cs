using System;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    public Transform StartPoint, EndPoint;
    public Action <GameObject>OnTrapDestroy;
}
