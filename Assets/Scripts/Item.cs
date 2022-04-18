using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	[Header("Item Type")]
	public bool isItem;
	public bool isWeapon;
	public bool isArmor;

	[Header("Item Details")]
	public string itemName;
	public string description;
	public int value;
	public Sprite itemSprite;

	[Header("Item Details")]
	public int amountToChange;
	public bool affectHp, affectMp, affectStrength;

	[Header("Weapon/Armor Details")]
	public int weaponStrength;
	public int armorStrength;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Use(int charToUseOn)
    {
		CharacterStats selectedCharacter = GameManager.instance.PlayerStats[charToUseOn];

        if (isItem)
        {
            if (affectHp)
            {
				selectedCharacter.CurrentHealth += amountToChange;
				if(selectedCharacter.CurrentHealth > selectedCharacter.MaximumHealth)
                {
					selectedCharacter.CurrentHealth = selectedCharacter.MaximumHealth;
                }
			}

            if (affectMp)
            {
				selectedCharacter.CurrentMp += amountToChange;
				if (selectedCharacter.CurrentMp > selectedCharacter.MaximumMp)
				{
					selectedCharacter.CurrentMp = selectedCharacter.MaximumMp;
				}
			}

			if (affectStrength)
            {
				selectedCharacter.Strength += amountToChange;
            }
        }

        if (isWeapon)
        {
			if(selectedCharacter.EquippedWeapon != "")
            {
				GameManager.instance.AddItem(selectedCharacter.EquippedWeapon);
            }

			selectedCharacter.EquippedWeapon = itemName;
			selectedCharacter.WeaponPower = weaponStrength;
        }

		if (isArmor)
        {
			if (selectedCharacter.EquippedArmor != "")
			{
				GameManager.instance.AddItem(selectedCharacter.EquippedArmor);
			}

			selectedCharacter.EquippedArmor = itemName;
			selectedCharacter.ArmorPower = armorStrength;
		}

		GameManager.instance.RemoveItem(itemName);
	}
}
