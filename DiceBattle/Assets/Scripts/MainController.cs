using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject prefabD4;
    public GameObject prefabD6;
    public GameObject prefabD8;
    public GameObject prefabD10;
    public GameObject prefabD12;
    public GameObject prefabD20;
    public GameObject prefabDxx;

    private Dictionary<int, GameObject> numToDicePrefabMap;

    public int maxEnemies = 6;
    private int currentEnemies = 0;

    GameObject[] enemies;
    List<GameObject> attackObjs;
    private bool isPlayerTurn;
    public bool isAttacking;
    private AttackController attackController;

    void Start()
    {
        isPlayerTurn = true;
        isAttacking = false;
        enemies = new GameObject[maxEnemies];
        attackObjs = new List<GameObject>();

        GameObject controllerObj = GameObject.FindWithTag("AttackController");
        attackController = controllerObj.GetComponent<AttackController>();

        numToDicePrefabMap = new Dictionary<int, GameObject> {
            {4, prefabD4},
            {6, prefabD6},
            {8, prefabD8},
            {10, prefabD10},
            {12, prefabD12},
            {20, prefabD20}
        };

        GenerateEnemy();
        GenerateEnemy();
        GenerateEnemy();
    }

    void Update()
    {
        if (isPlayerTurn)
        {
            // stuff
        }
        else
        {
            GenerateEnemy();
            isPlayerTurn = true;
        }
    }

    public void GenerateEnemy()
    {
        if (currentEnemies >= maxEnemies)
        {
            // TODO: player loses
            return;
        }
        currentEnemies++;
        enemies[currentEnemies - 1] = Instantiate(enemyPrefab, new Vector3(currentEnemies * 3 - 10f, 3f, 0), Quaternion.identity);
    }

    public void StartAttack(int attackNum)
    {
        if (isAttacking)
        {
            return;
        }
        List<(int, int)> rolls = attackController.DoAttack(attackNum);
        isAttacking = true;

        // each roll is (dice size, roll value)
        foreach (var roll in rolls)
        {
            if (numToDicePrefabMap.ContainsKey(roll.Item1))
            {
                attackObjs.Add(Instantiate(numToDicePrefabMap[roll.Item1]));
            }
            else
            {
                attackObjs.Add(Instantiate(prefabDxx));
            }
            attackObjs[^1].transform.position = new Vector3(attackObjs.Count * 2.5f - 7f, 0.25f, 0.1f);
        }
    }

    public Dictionary<int, int> GetAttack(int attackNum)
    {
        return attackController.GetAttackStats(attackNum);
    }
}

