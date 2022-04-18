using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour {

	private bool canPickUp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(canPickUp && Input.GetButtonDown("Fire1") && PlayerController.instance.CanMove)
        {
			GameManager.instance.AddItem(GetComponent<Item>().itemName);
			Destroy(gameObject);
        }
	}

	void OnTriggerEnter2D(Collider2D other)
    {
		if(other.tag == "Player")
        {
			canPickUp = true;
        }
    }

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			canPickUp = false;
		}
	}
}
