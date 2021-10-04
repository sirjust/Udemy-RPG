using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public CharacterStats[] PlayerStats;

	public bool GameMenuOpen, DialogActive, FadingBetweenAreas;

	// Use this for initialization
	void Start () {
		instance = this;

		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if(GameMenuOpen || DialogActive || FadingBetweenAreas)
        {
			PlayerController.instance.CanMove = false;
        } else
        {
			PlayerController.instance.CanMove = true;
        }
	}
}
