using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour {
	public GameObject Menu;
	public GameObject[] Windows;

    private CharacterStats[] PlayerStats;

	public Text[] NameText, HpText, MpText, LvlText, ExpText;
	public Slider[] ExpSlider;
	public Image[] CharImage;
	public GameObject[] CharStatHolder;

	public GameObject[] StatusButtons;

	public Text StatusName, StatusHp, StatusMp, StatusStrength, StatusDefense, StatusWeaponEquipped, StatusWeaponPower, StatusArmorEquipped, StatusArmorPower, StatusExp;
	public Image StatusImage;

	public ItemButton[] itemButtons;
	public string selectedItem;
	public Item activeItem;
	public Text itemName, itemDescription, useButtonText;

	public static GameMenu instance;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire2"))
        {
            if (Menu.activeInHierarchy)
            {
				//Menu.SetActive(false);
				//GameManager.instance.GameMenuOpen = false;
				CloseMenu();
			} else
            {
				Menu.SetActive(true);
				UpdateMainStats();
				GameManager.instance.GameMenuOpen = true;
			}
        }
	}

	public void UpdateMainStats()
    {
		PlayerStats = GameManager.instance.PlayerStats;

        for (int i = 0; i < PlayerStats.Length; i++)
        {
            if (PlayerStats[i].gameObject.activeInHierarchy)
            {
				CharStatHolder[i].SetActive(true);

				NameText[i].text = PlayerStats[i].CharacterName;
				HpText[i].text = "HP: " + PlayerStats[i].CurrentHealth + "/" + PlayerStats[i].MaximumHealth;
				MpText[i].text = "MP: " + PlayerStats[i].CurrentMp + "/" + PlayerStats[i].MaximumMp;
				LvlText[i].text = "Level: " + PlayerStats[i].PlayerLevel;
				ExpText[i].text = "" + PlayerStats[i].CurrentExp + "/" + PlayerStats[i].ExpToNextLevel[PlayerStats[i].PlayerLevel];
				ExpSlider[i].maxValue = PlayerStats[i].ExpToNextLevel[PlayerStats[i].PlayerLevel];
				ExpSlider[i].value = PlayerStats[i].CurrentExp;
				CharImage[i].sprite = PlayerStats[i].CharacterImage;
			} else
            {
				CharStatHolder[i].SetActive(false);
            }
        }
    }

	public void ToggleWindow(int windowNumber)
    {
		UpdateMainStats();

        for (int i = 0; i < Windows.Length; i++)
        {
			if(i == windowNumber)
            {
				Windows[i].SetActive(!Windows[i].activeInHierarchy);
            } else
            {
				Windows[i].SetActive(false);
            }
        }
    }

	public void CloseMenu()
    {
        for (int i = 0; i < Windows.Length; i++)
        {
			Windows[i].SetActive(false);
        }

		Menu.SetActive(false);

		GameManager.instance.GameMenuOpen = false;
    }

	public void OpenStatus()
    {
		UpdateMainStats();

		// Update information that is shown
		StatusCharacter(0);

        for (int i = 0; i < StatusButtons.Length; i++)
        {
			StatusButtons[i].SetActive(PlayerStats[i].gameObject.activeInHierarchy);
			StatusButtons[i].GetComponentInChildren<Text>().text = PlayerStats[i].CharacterName;
        }
    }

	public void StatusCharacter(int selected)
    {
		StatusName.text = PlayerStats[selected].CharacterName;
		StatusHp.text = "" + PlayerStats[selected].CurrentHealth + "/" + PlayerStats[selected].MaximumHealth;
		StatusMp.text = "" + PlayerStats[selected].CurrentMp + "/" + PlayerStats[selected].MaximumMp;
		StatusStrength.text = PlayerStats[selected].Strength.ToString();
		StatusDefense.text = PlayerStats[selected].Defense.ToString();
		StatusWeaponEquipped.text = !string.IsNullOrEmpty(PlayerStats[selected].EquippedWeapon) ? PlayerStats[selected].EquippedWeapon : "None";
		StatusWeaponPower.text = PlayerStats[selected].WeaponPower.ToString();
		StatusArmorEquipped.text = !string.IsNullOrEmpty(PlayerStats[selected].EquippedArmor) ? PlayerStats[selected].EquippedArmor : "None";
		StatusArmorPower.text = PlayerStats[selected].ArmorPower.ToString();
		StatusExp.text = (PlayerStats[selected].ExpToNextLevel[PlayerStats[selected].PlayerLevel] - PlayerStats[selected].CurrentExp).ToString();

		StatusImage.sprite = PlayerStats[selected].CharacterImage;
	}

	public void ShowItems()
    {
		GameManager.instance.SortItems();

        for (int i = 0; i < itemButtons.Length; i++)
        {
			itemButtons[i].buttonValue = i;

			if(GameManager.instance.itemsHeld[i] != "")
            {
				itemButtons[i].buttonImage.gameObject.SetActive(true);
				itemButtons[i].buttonImage.sprite = GameManager.instance.GetItemDetails(GameManager.instance.itemsHeld[i]).itemSprite;
				itemButtons[i].amountText.text = GameManager.instance.numberOfItems[i].ToString();
            } else
            {
				itemButtons[i].buttonImage.gameObject.SetActive(false);
				itemButtons[i].amountText.text = "";
            }
        }
    }

	public void SelectItem(Item newItem)
    {
		activeItem = newItem;

        if (activeItem.isItem)
        {
			useButtonText.text = "Use";
        }

		if (activeItem.isWeapon || activeItem.isArmor)
        {
			useButtonText.text = "Equip";
        }

		itemName.text = activeItem.itemName;
		itemDescription.text = activeItem.description;
    }
}
