using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class AttackButton : MonoBehaviour
{
	public Button button;
	private TextMeshProUGUI text;

	public int attackNum;
	public GameObject controllerObj;
	private MainController controller;

	void Start()
	{
		Button btn = button.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		controller = controllerObj.GetComponent<MainController>();
		text = button.GetComponentInChildren<TextMeshProUGUI>();
	}
	void Update()
	{
		UpdateText();
		button.interactable = !controller.isAttacking;
	}

	void TaskOnClick()
	{
		controller.StartAttack(attackNum);
	}

	public void UpdateText()
    {
		Dictionary<int, int> dice = controller.GetAttack(attackNum);
        string info = "";
        foreach (var die in dice)
		{
			if (info != "")
            {
				info += ", ";
            }
			info += die.Value + "d" + die.Key;
		}
		text.SetText(info);
	}
}
