using UnityEngine;
using System.Collections.Generic;

public class AttackController : MonoBehaviour
{
    // Start is called before the first frame update
    private List<Dictionary<int, int>> attacks = new List<Dictionary<int, int>>();
    void Start()
    {
        // set the 4 attacks
        // 2d20
        attacks.Add(new Dictionary<int, int>{
            {20, 2}
        });
        // 3d10
        attacks.Add(new Dictionary<int, int>{
            {10, 3}
        });
        // 1d12, 3d4
        attacks.Add(new Dictionary<int, int>{
            {12, 1}, {4, 3}
        });
        // 1d10, 1d8, 1d6, 1d4
        attacks.Add(new Dictionary<int, int>{
            {10, 1}, {8, 1}, {6, 1}, {4, 1}
        });
    }

    // list of (dice size, roll)
    List<(int, int)> RollNums(int attackNum)
    {
        Dictionary<int, int> dice = attacks[attackNum];
        List<(int, int)> rolls = new List<(int, int)>();
        foreach (var die in dice)
        {
            for (int i = 0; i < die.Value; i++)
            {
                int val = Random.Range(1, die.Key + 1);
                rolls.Add((die.Key, val));
            }
        }
        return rolls;
    }

    public List<(int, int)> DoAttack(int attackNum)
    {
        return RollNums(attackNum);
    }

    public Dictionary<int, int> GetAttackStats(int attackNum)
    {
        return attacks[attackNum];
    }
}
