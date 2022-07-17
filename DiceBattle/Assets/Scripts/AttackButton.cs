using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class AttackButton : MonoBehaviour
{
	public Button button;
	// the base attack / dice roll
	// key: dx  value: number of dice
	private Dictionary<int, int> dice;

	void Start()
	{
		Button btn = button.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		dice = new Dictionary<int, int>
		{
			{4, 2 },
            {8, 1 }
		};
	}

	List<int> RollNums()
    {
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

	void TaskOnClick()
	{ 
		Debug.Log(GetText());
		List<int> rolls = RollNums();
		string rollstring = "You have rolled:";
		foreach (var roll in rolls)
        {
			rollstring = rollstring + " " + roll;
        }
		Debug.Log(rollstring);
	}

	public string GetText()
    {
        string result = "";
        foreach (var die in dice)
		{
			if (result != "")
            {
				result += ", ";
            }
			result = result + die.Value + "d" + die.Key;
		}
		return result;
	}
}
