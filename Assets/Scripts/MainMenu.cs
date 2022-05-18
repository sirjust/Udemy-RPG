using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string newGameScene;
	public string loadGameScene;

	public GameObject continueButton;

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("Current_Scene"))
        {
			continueButton.SetActive(true);
        }
        else
        {
			continueButton.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Continue()
    {
		SceneManager.LoadScene(loadGameScene);
    }

	public void NewGame()
    {
		SceneManager.LoadScene(newGameScene);
    }

	public void Exit()
    {
		// We can't test this when running in Unity, only after game is built
		Application.Quit();
    }
}
