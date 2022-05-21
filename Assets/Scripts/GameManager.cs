using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public CharacterStats[] PlayerStats;

	public bool GameMenuOpen, DialogActive, FadingBetweenAreas, ShopActive, BattleActive;

	public string[] itemsHeld;
	public int[] numberOfItems;
	public Item[] referenceItems;

	public int currentGold;

	// Use this for initialization
	void Start () {
		instance = this;

		DontDestroyOnLoad(gameObject);

		SortItems();
	}
	
	// Update is called once per frame
	void Update () {
		if(GameMenuOpen || DialogActive || FadingBetweenAreas || ShopActive || BattleActive)
        {
			PlayerController.instance.CanMove = false;
        } else
        {
			PlayerController.instance.CanMove = true;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
			AddItem("Iron Armor");
			AddItem("Blabla");
			RemoveItem("Health Potion");
			RemoveItem("Bogus Item");
        }

		if (Input.GetKeyDown(KeyCode.O))
		{
			SaveData();
		}

		if (Input.GetKeyDown(KeyCode.P))
        {
			LoadData();
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

	public void AddItem(string itemToAdd)
    {
		int newItemPosition = 0;
		bool foundSpace = false;

        for (int i = 0; i < itemsHeld.Length; i++)
        {
			if(itemsHeld[i] == "" || itemsHeld[i] == itemToAdd)
            {
				newItemPosition = i;
				i = itemsHeld.Length;
				foundSpace = true;
            }
        }

        if (foundSpace)
        {
			bool itemExists = false;
			for(int i = 0; i < referenceItems.Length; i++)
            {
				if(referenceItems[i].itemName == itemToAdd)
                {
					itemExists = true;
					i = referenceItems.Length;
                }
            }

            if (itemExists)
            {
				itemsHeld[newItemPosition] = itemToAdd;
				numberOfItems[newItemPosition]++;
            } else
            {
				Debug.LogError(itemToAdd + " does not exist");
            }
        }

		GameMenu.instance.ShowItems();
    }

	public void RemoveItem(string itemToRemove)
    {
		bool foundItem = false;
		int itemPosition = 0;

        for (int i = 0; i < itemsHeld.Length; i++)
        {
			if(itemsHeld[i] == itemToRemove)
            {
				foundItem = true;
				itemPosition = i;

				i = itemsHeld.Length;
            }
        }
        if (foundItem)
        {
			numberOfItems[itemPosition]--;

			if(numberOfItems[itemPosition] <= 0)
            {
				itemsHeld[itemPosition] = "";
            }

			GameMenu.instance.ShowItems();
        } else
        {
			Debug.LogError("Couldn't find " + itemToRemove);
        }
    }

	public void SaveData()
    {
		PlayerPrefs.SetString("Current_Scene", SceneManager.GetActiveScene().name);
		PlayerPrefs.SetFloat("Player_Position_X", PlayerController.instance.transform.position.x);
		PlayerPrefs.SetFloat("Player_Position_Y", PlayerController.instance.transform.position.y);
		PlayerPrefs.SetFloat("Player_Position_Z", PlayerController.instance.transform.position.z);

		for(int i = 0; i < PlayerStats.Length; i++)
        {
            if (PlayerStats[i].gameObject.activeInHierarchy)
            {
				PlayerPrefs.SetInt("Player_" + PlayerStats[i].CharacterName + "_active", 1);
            } else
            {
				PlayerPrefs.SetInt("Player_" + PlayerStats[i].CharacterName + "_active", 0);
			}

			PlayerPrefs.SetInt("Player_" + PlayerStats[i].CharacterName + "_Level", PlayerStats[i].PlayerLevel);
			PlayerPrefs.SetInt("Player_" + PlayerStats[i].CharacterName + "_CurrentExp", PlayerStats[i].CurrentExp);
			PlayerPrefs.SetInt("Player_" + PlayerStats[i].CharacterName + "_CurrentHP", PlayerStats[i].CurrentHealth);
			PlayerPrefs.SetInt("Player_" + PlayerStats[i].CharacterName + "_MaxHP", PlayerStats[i].MaximumHealth);
			PlayerPrefs.SetInt("Player_" + PlayerStats[i].CharacterName + "_CurrentMP", PlayerStats[i].CurrentMp);
			PlayerPrefs.SetInt("Player_" + PlayerStats[i].CharacterName + "_MaxMP", PlayerStats[i].MaximumMp);
			PlayerPrefs.SetInt("Player_" + PlayerStats[i].CharacterName + "_Strength", PlayerStats[i].Strength);
			PlayerPrefs.SetInt("Player_" + PlayerStats[i].CharacterName + "_Defense", PlayerStats[i].Defense);
			PlayerPrefs.SetInt("Player_" + PlayerStats[i].CharacterName + "_WpnPwr", PlayerStats[i].WeaponPower);
			PlayerPrefs.SetInt("Player_" + PlayerStats[i].CharacterName + "_ArmorPwr", PlayerStats[i].ArmorPower);
			PlayerPrefs.SetString("Player_" + PlayerStats[i].CharacterName + "_EquippedWeapon", PlayerStats[i].EquippedWeapon);
			PlayerPrefs.SetString("Player_" + PlayerStats[i].CharacterName + "_EquippedArmor", PlayerStats[i].EquippedArmor);
		}

		// Store inventory data
		for (int i = 0; i < itemsHeld.Length; i++)
        {
			PlayerPrefs.SetString("ItemInInventory_" + i, itemsHeld[i]);
			PlayerPrefs.SetInt("ItemAmount_" + i, numberOfItems[i]);
        }
	}

	public void LoadData()
    {
		PlayerController.instance.transform.position = new Vector3(PlayerPrefs.GetFloat("Player_Position_X"), PlayerPrefs.GetFloat("Player_Position_Y"), PlayerPrefs.GetFloat("Player_Position_Z"));

		for (int i = 0; i < PlayerStats.Length; i++)
        {
			if(PlayerPrefs.GetInt("Player_" + PlayerStats[i].CharacterName + "_active") == 0)
            {
				PlayerStats[i].gameObject.SetActive(false);
            } else
            {
				PlayerStats[i].gameObject.SetActive(true);
            }

			PlayerStats[i].PlayerLevel = PlayerPrefs.GetInt("Player_" + PlayerStats[i].CharacterName + "_Level");
			PlayerStats[i].CurrentExp = PlayerPrefs.GetInt("Player_" + PlayerStats[i].CharacterName + "_CurrentExp");
			PlayerStats[i].CurrentHealth = PlayerPrefs.GetInt("Player_" + PlayerStats[i].CharacterName + "_CurrentHP");
			PlayerStats[i].MaximumHealth = PlayerPrefs.GetInt("Player_" + PlayerStats[i].CharacterName + "_MaxHP");
			PlayerStats[i].CurrentMp = PlayerPrefs.GetInt("Player_" + PlayerStats[i].CharacterName + "_CurrentMP");
			PlayerStats[i].MaximumMp = PlayerPrefs.GetInt("Player_" + PlayerStats[i].CharacterName + "_MaxMP");
			PlayerStats[i].Strength = PlayerPrefs.GetInt("Player_" + PlayerStats[i].CharacterName + "_Strength");
			PlayerStats[i].Defense = PlayerPrefs.GetInt("Player_" + PlayerStats[i].CharacterName + "_Defense");
			PlayerStats[i].WeaponPower = PlayerPrefs.GetInt("Player_" + PlayerStats[i].CharacterName + "_WpnPwr");
			PlayerStats[i].ArmorPower = PlayerPrefs.GetInt("Player_" + PlayerStats[i].CharacterName + "_ArmorPwr");
			PlayerStats[i].EquippedWeapon = PlayerPrefs.GetString("Player_" + PlayerStats[i].CharacterName + "_EquippedWeapon");
			PlayerStats[i].EquippedArmor = PlayerPrefs.GetString("Player_" + PlayerStats[i].CharacterName + "_EquippedArmor");
		}

		// Store inventory data
		for (int i = 0; i < itemsHeld.Length; i++)
		{
			itemsHeld[i] = PlayerPrefs.GetString("ItemInInventory_" + i);
			numberOfItems[i] = PlayerPrefs.GetInt("ItemAmount_" + i);
		}
	}
}
