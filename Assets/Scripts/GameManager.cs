using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public CharacterStats[] PlayerStats;

	public bool GameMenuOpen, DialogActive, FadingBetweenAreas;

	public string[] itemsHeld;
	public int[] numberOfItems;
	public Item[] referenceItems;

	// Use this for initialization
	void Start () {
		instance = this;

		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if(GameMenuOpen || DialogActive || FadingBetweenAreas)
        {
			PlayerController.instance.CanMove = false;
        } else
        {
			PlayerController.instance.CanMove = true;
        }
	}

	public Item	GetItemDetails(string itemName)
    {
        for (int i = 0; i < referenceItems.Length; i++)
        {
			if(referenceItems[i].itemName == itemName)
            {
				return referenceItems[i];
            }
        }

		return null;
    }

	public void SortItems()
    {
		bool itemAfterSpace = true;

        while (itemAfterSpace)
        {
			itemAfterSpace = false;
			for (int i = 0; i < itemsHeld.Length - 1; i++)
			{
				if (itemsHeld[i] == "")
				{
					itemsHeld[i] = itemsHeld[i + 1];
					itemsHeld[i + 1] = "";

					numberOfItems[i] = numberOfItems[i + 1];
					numberOfItems[i + 1] = 0;

					if (itemsHeld[i] != "") itemAfterSpace = true;
				}
			}
		}
    }
}
