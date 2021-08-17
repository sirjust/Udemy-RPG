using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform Target;

	// Use this for initialization
	void Start () {
		Target = PlayerController.instance.transform;
	}
	
	// LateUpdate is called once per frame after Update
	void LateUpdate () {
		transform.position = new Vector3(Target.position.x, Target.position.y, transform.position.z);
	}
}
