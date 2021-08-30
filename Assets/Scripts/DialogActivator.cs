﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator: MonoBehaviour {

	public string[] Lines;

	private bool CanActivate;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (CanActivate && Input.GetButtonDown("Fire1") && !DialogManager.instance.DialogBox.activeInHierarchy)
        {
			DialogManager.instance.ShowDialog(Lines);
        }
	}

	private void OnTriggerEnter2D(Collider2D other)
    {
		if(other.tag == "Player")
        {
			CanActivate = true;
        }
    }

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			CanActivate = false;
		}
	}
}
