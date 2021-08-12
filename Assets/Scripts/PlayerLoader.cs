using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour {

	public GameObject Player;

	// Use this for initialization
	void Start () {
		if (PlayerController.instance == null) Instantiate(Player);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
