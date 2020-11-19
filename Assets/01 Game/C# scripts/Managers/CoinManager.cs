using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoinManager : MonoBehaviour
{
    [SerializeField] private GameObject CoinWindow;
    public int Coins;
    void Start()
    {
        Instantiate(CoinWindow,GameManager.Instance.Canvas.transform);
        GameManager.Instance.PlayerControllerScript.OnEnemyTouch += (value)=>
        {
            Coins++;
        };

    }
    
    
}
