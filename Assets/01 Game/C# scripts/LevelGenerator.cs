using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> planePrefabs = new List<GameObject>();
    
    //settings
    [SerializeField, Range(2, 5)] private int destroyAfterTime;
    [SerializeField, Range(5, 15)] private int startTraps;
    [SerializeField, Range(15, 30)] private int maxTraps;
    
    
    [SerializeField] private int trapCounter = 1;
    [SerializeField] private GameObject currentPlane;

    void Start()
    {
        for (int i = 0; i < startTraps; i++)
        {
            GenerateTrap();
        }
    }

    private void GenerateTrap()
    {
        if (trapCounter == maxTraps) return;
        
        trapCounter++;
        
        var currentTrapContoller = currentPlane.GetComponent<TrapController>();
        
        var randomTrap = planePrefabs[Random.Range(0, planePrefabs.Count)];
        
        var spawnedPlane = Instantiate(randomTrap);
        var spawnedTrapController = spawnedPlane.GetComponent<TrapController>();
        spawnedTrapController.OnTrapDestroy += DestroyTrap;
        
        spawnedPlane.transform.position = currentTrapContoller.EndPoint.position;
        var distance = Vector3.Distance(currentTrapContoller.EndPoint.position,
            spawnedTrapController.StartPoint.position);
        spawnedPlane.transform.position += new Vector3(0, 0, distance);

        currentPlane = spawnedPlane;
    }

    private void DestroyTrap(GameObject trap)
    {
        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(destroyAfterTime);
        sequence.AppendCallback(() =>
        {
            Destroy(trap);
            trapCounter--;
        });
        GenerateTrap();
    }
}