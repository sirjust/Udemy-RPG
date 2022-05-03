using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

	public static Shop instance;

	public GameObject shopMenu;
	public GameObject buyMenu;
	public GameObject sellMenu;

	public Text goldText;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.K) && !shopMenu.activeInHierarchy) 
		{
			OpenShop();
		}
	}

	public void OpenShop()
    {
		shopMenu.SetActive(true);
		OpenBuyMenu();

		GameManager.instance.ShopActive = true;

		goldText.text = GameManager.instance.currentGold.ToString() + "g";
    }

	public void CloseShop()
    {
		shopMenu.SetActive(false);

		GameManager.instance.ShopActive = true;
    }

	public void OpenBuyMenu()
    {
		buyMenu.SetActive(true);
		sellMenu.SetActive(false);
    }

	public void OpenSellMenu()
    {
		sellMenu.SetActive(true);
		buyMenu.SetActive(false);
    }
}
