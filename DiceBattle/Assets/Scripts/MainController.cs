using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public GameObject EnemyPrefab;

    void Start()
    {
        GenerateEnemy();
    }

    void Update()
    {
        
    }

    public void GenerateEnemy()
    {
        Instantiate(EnemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
