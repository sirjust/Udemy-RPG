﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour {

	public string AreaToLoad;

	public string AreaTransitionName;

	public AreaEntrance Entrance;

	// Use this for initialization
	void Start () {
		Entrance.TransitionName = AreaTransitionName;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other)
    {
		if(other.tag == "Player")
        {
			SceneManager.LoadScene(AreaToLoad);

			PlayerController.instance.AreaTransitionName = AreaTransitionName;
        }
    }
}
