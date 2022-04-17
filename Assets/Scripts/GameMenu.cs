using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour {
	public GameObject Menu;

	private CharacterStats[] PlayerStats;

	public Text[] NameText, HpText, MpText, LvlText, ExpText;
	public Slider[] ExpSlider;
	public Image[] CharImage;
	public GameObject[] CharStatHolder;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire2"))
        {
            if (Menu.activeInHierarchy)
            {
				Menu.SetActive(false);
				GameManager.instance.GameMenuOpen = false;
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
}
