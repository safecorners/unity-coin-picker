using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnRate = 1.0f;
    public float spawnPointY = 5.0f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnCoin), 1.0f, spawnRate);
    }

    void SpawnCoin()
    {
        float spawnPointX = Random.Range(-2.5f, 2.5f);
        Vector2 randomPosition = new Vector2(spawnPointX, spawnPointY);
        Instantiate(coinPrefab, randomPosition, Quaternion.identity);
    }
}
