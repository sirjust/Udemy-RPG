using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour {

	public Transform Target;
	public Tilemap Map;
	private Vector3 BottomLeftLimit;
	private Vector3 TopRightLimit;

	private float HalfHeight;
	private float HalfWidth;

	public int musicToPlay;
	private bool musicStarted;

	// Use this for initialization
	void Start () {
		Target = FindObjectOfType<PlayerController>().transform;

		HalfHeight = Camera.main.orthographicSize;
		HalfWidth = HalfHeight * Camera.main.aspect;

		BottomLeftLimit = Map.localBounds.min + new Vector3(HalfWidth, HalfHeight, 0f);
		TopRightLimit = Map.localBounds.max + new Vector3(-HalfWidth, -HalfHeight, 0f);

		PlayerController.instance.SetBounds(Map.localBounds.min, Map.localBounds.max);
	}
	
	// LateUpdate is called once per frame after Update
	void LateUpdate () {
		transform.position = new Vector3(Target.position.x, Target.position.y, transform.position.z);

		// Keep camera inside bounds
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, BottomLeftLimit.x, TopRightLimit.x), Mathf.Clamp(transform.position.y, BottomLeftLimit.y, TopRightLimit.y), transform.position.z);

        if (!musicStarted)
        {
			musicStarted = true;
			AudioManager.instance.PlayBGM(musicToPlay);
        }
	}
}
