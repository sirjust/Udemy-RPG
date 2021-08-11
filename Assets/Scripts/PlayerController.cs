using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D playerRigidbody;
    public float moveSpeed;

    public Animator anim;

    public static PlayerController instance;

    public string AreaTransitionName;

	// Use this for initialization
	void Start () {
        if (instance == null) instance = this;
        else Destroy(gameObject); 

        DontDestroyOnLoad(gameObject);
        moveSpeed = 3f;
	}
	
	// Update is called once per frame
	void Update () {
        playerRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;

        anim.SetFloat("moveX", playerRigidbody.velocity.x);
        anim.SetFloat("moveY", playerRigidbody.velocity.y);

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            anim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }
    }
}
