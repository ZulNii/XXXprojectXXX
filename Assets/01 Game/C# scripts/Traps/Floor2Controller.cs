using System.Collections.Generic;
using UnityEngine;

public class Floor2Controller : MonoBehaviour
{
    private const int enemyTypesCount = 1;

    [SerializeField] private List<GameObject > enemyTypes = new List<GameObject>();
    void Start()
    {
        SpawnRandomEnemyType();
    }

    private void SpawnRandomEnemyType()
    {
        for (int i = 0; i < enemyTypesCount; i++)
        {
            var randomType = enemyTypes[Random.Range(0, enemyTypes.Count)];
            randomType.SetActive(true);
        }
    }
}