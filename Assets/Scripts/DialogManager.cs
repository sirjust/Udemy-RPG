using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

	public Text DialogText;
	public Text NameText;
	public GameObject DialogBox;
	public GameObject NameBox;

	public string[] DialogLines;
	public int CurrentLine;
	private bool JustStarted;

	public static DialogManager instance;

	// Use this for initialization
	void Start () {
		instance = this;
		// DialogText.text = DialogLines[CurrentLine];
	}
	
	// Update is called once per frame
	void Update () {
        if (DialogBox.activeInHierarchy)
        {
			if (Input.GetButtonUp("Fire1"))
			{
				if (!JustStarted)
				{
					{
						CurrentLine++;
						if (CurrentLine >= DialogLines.Length)
						{
							DialogBox.SetActive(false);
							PlayerController.instance.CanMove = true;
						}
						else DialogText.text = DialogLines[CurrentLine];
					}
				}
				else
				{
					JustStarted = false;
				}
			}
        }
	}

	public void ShowDialog(string[] lines)
    {
		DialogLines = lines;
		CurrentLine = 0;

		DialogText.text = DialogLines[CurrentLine];
		DialogBox.SetActive(true);

		JustStarted = true;

		PlayerController.instance.CanMove = false;
	}
}
