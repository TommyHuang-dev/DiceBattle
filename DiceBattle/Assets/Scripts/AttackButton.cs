using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class AttackButton : MonoBehaviour
{
	public Button button;
	private TextMeshProUGUI text;

	private Dictionary<int, int> dice;
	// private int rerolls;

	void Start()
	{
		Button btn = button.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);

		// key: dx  value: number of dice
		dice = new Dictionary<int, int>
		{
			{4, 2 },
            {8, 1 }
		};

		text = button.GetComponentInChildren<TextMeshProUGUI>();
		text.SetText(GetText());
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
		Debug.Log(text);
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
