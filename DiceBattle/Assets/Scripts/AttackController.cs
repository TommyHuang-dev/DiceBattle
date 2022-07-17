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
            {12, 3}
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

    // Update is called once per frame
    void Update()
    {

    }

    List<int> RollNums(int attackNum)
    {
        Dictionary<int, int> dice = attacks[attackNum];
        List<int> rolls = new List<int>();
        foreach (var die in dice)
        {
            for (int i = 0; i < die.Value; i++)
            {
                rolls.Add(Random.Range(1, die.Key + 1));
            }
        }
        return rolls;
    }

    public void DoAttack(int attackNum)
    {
        Debug.Log("attacking with attack " + attackNum);
    }

    public Dictionary<int, int> GetAttack(int attackNum)
    {
        return attacks[attackNum];
    }
}
