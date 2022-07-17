using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public int maxEnemies = 6;
    GameObject[] Enemies;

    void Start()
    {
        Enemies = new GameObject[maxEnemies];
    }

    void Update()
    {
        // GenerateEnemy();
    }

    public void GenerateEnemy()
    {
        for (int i = 0; i < maxEnemies; i++) {
            if (Enemies[i] == null) {
                Enemies[i] = Instantiate(EnemyPrefab, new Vector3(i * 3 - 7.5f, 2.5f, 0), Quaternion.identity);
                break;
            }
        }
    }
}
