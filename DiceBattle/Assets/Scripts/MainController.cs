using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int maxEnemies = 6;

    GameObject[] enemies;
    private bool isPlayerTurn;
    private AttackController attackController;

    void Start()
    {
        enemies = new GameObject[maxEnemies];
        isPlayerTurn = false;
        GameObject controllerObj = GameObject.FindWithTag("AttackController");
        attackController = controllerObj.GetComponent<AttackController>();
        GenerateEnemy();
    }

    void Update()
    {
        // GenerateEnemy();
    }

    public void GenerateEnemy()
    {
        for (int i = 0; i < maxEnemies; i++) {
            if (enemies[i] == null) {
                enemies[i] = Instantiate(enemyPrefab, new Vector3(i * 3 - 7.5f, 2.5f, 0), Quaternion.identity);
                break;
            }
        }
    }
}
