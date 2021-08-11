using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour {

	public string TransitionName;

	// Use this for initialization
	void Start () {
		if (TransitionName == PlayerController.instance.AreaTransitionName) PlayerController.instance.transform.position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
