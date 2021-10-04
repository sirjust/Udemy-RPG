using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour {
	public GameObject Menu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire2"))
        {
            if (Menu.activeInHierarchy)
            {
				Menu.SetActive(false);
				GameManager.instance.GameMenuOpen = false;
            } else
            {
				Menu.SetActive(true);
				GameManager.instance.GameMenuOpen = true;
			}
        }
	}
}
