using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D playerRigidbody;
    public float moveSpeed;

    public Animator anim;

    public static PlayerController instance;

    public string AreaTransitionName;

    private Vector3 BottomLeftLimit;
    private Vector3 TopRightLimit;

    public bool CanMove = true;

	// Use this for initialization
	void Start () {
        if (instance == null) instance = this;
        else
        {
            if(instance != this) Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        moveSpeed = 5f;
	}
	
	// Update is called once per frame
	void Update () {
        if (CanMove)
        {
            playerRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
        }
        else
        {
            playerRigidbody.velocity = Vector2.zero;
        }

        anim.SetFloat("moveX", playerRigidbody.velocity.x);
        anim.SetFloat("moveY", playerRigidbody.velocity.y);

        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            if (CanMove)
            {
                anim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
                anim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
            }
        }

        // Keep player inside bounds
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, BottomLeftLimit.x, TopRightLimit.x), Mathf.Clamp(transform.position.y, BottomLeftLimit.y, TopRightLimit.y), transform.position.z);
    }

    public void SetBounds(Vector3 bottomLeft, Vector3 topRight)
    {
        BottomLeftLimit = bottomLeft + new Vector3(.5f, 1f, 0f);
        TopRightLimit = topRight + new Vector3(-.5f, -1f, 0f);
    }
}
