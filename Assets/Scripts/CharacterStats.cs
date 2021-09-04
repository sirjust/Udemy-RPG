using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour {

	public string CharacterName;
	public int PlayerLevel = 1;
	public int CurrentExp;
	public int[] ExpToNextLevel;
	public int MaxLevel = 100;
	public int BaseExp = 1000;

	public int CurrentHealth;
	public int MaximumHealth = 100;
	public int CurrentMp;
	public int MaximumMp = 30;
	public int[] MpLevelBonus;
	public int Strength;
	public int Defense;
	public int WeaponPower;
	public int ArmorPower;
	public string EquippedWeapon;
	public string EquippedArmor;
	public Sprite CharacterImage;

	// Use this for initialization
	void Start () {
		ExpToNextLevel = new int[MaxLevel];
		ExpToNextLevel[1] = BaseExp;

		for(int i=2; i < ExpToNextLevel.Length; i++)
        {
			ExpToNextLevel[i] = Mathf.FloorToInt(ExpToNextLevel[i - 1] * 1.05f);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.K))
        {
			AddExp(1000);
        }
	}

	public void AddExp(int ExpToAdd)
    {
		CurrentExp += ExpToAdd;
		if(PlayerLevel < MaxLevel)
        {
			if (CurrentExp > ExpToNextLevel[PlayerLevel])
			{
				CurrentExp -= ExpToNextLevel[PlayerLevel];
				PlayerLevel++;

				// Determine whether to add strength or defense
				if (PlayerLevel % 2 == 0)
				{
					Strength++;
				}
				else
				{
					Defense++;
				}

				MaximumHealth = Mathf.FloorToInt(MaximumHealth * 1.05f);
				CurrentHealth = MaximumHealth;

				MaximumMp += MpLevelBonus[PlayerLevel];
				CurrentMp = MaximumMp;
			}
			if(PlayerLevel >= MaxLevel)
			{
				CurrentExp = 0;
			}
		}
    }
}
