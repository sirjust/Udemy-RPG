using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D playerRigidbody;
    public float moveSpeed;

    public Animator anim;

	// Use this for initialization
	void Start () {
        moveSpeed = 3f;
	}
	
	// Update is called once per frame
	void Update () {
        playerRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;

        anim.SetFloat("moveX", playerRigidbody.velocity.x);
        anim.SetFloat("moveY", playerRigidbody.velocity.y);
	}
}
