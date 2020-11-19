using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinWindow : MonoBehaviour
{
    [SerializeField] private Image coinImage;
    [SerializeField] private Image coinImagePrefab;
    [SerializeField] private GameObject coinContainer;
    [SerializeField] private TextMeshProUGUI coinsText;
    private int coinCounter;
    private void Start()
    {
        GameManager.Instance.PlayerControllerScript.OnEnemyTouch += CreateCoin;
    }

    private void OnDestroy()
    {
        GameManager.Instance.PlayerControllerScript.OnEnemyTouch -= CreateCoin;
    }

    private void CreateCoin(Transform transform)
    {
       
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        
        var coin = Instantiate(coinImagePrefab,coinContainer.transform);
        coin.transform.position = screenPos;
        coin.transform.DOMove(coinImage.transform.position, 0.8f).OnComplete(() =>
        {
            coinCounter++;
            coinsText.SetText($"{coinCounter}");
        });
    }
}
