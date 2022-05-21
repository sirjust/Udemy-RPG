using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

	public static BattleManager instance;

	private bool battleActive;

	public GameObject battleScene;

	public Transform[] playerPositions;
	public Transform[] enemyPositions;

	public BattleChar[] playerPrefabs;
	public BattleChar[] enemyPrefabs;

	public List<BattleChar> activeBattlers = new List<BattleChar>();

	// Use this for initialization
	void Start () {
		instance = this;
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.T))
        {
			BattleStart(new string[] { "Eyeball", "Spider" });
        }
	}

	public void BattleStart(string[] enemiesToSpawn)
    {
        if (!battleActive)
        {
			battleActive = true;

			GameManager.instance.BattleActive = true;

			transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, transform.position.z);
			battleScene.SetActive(true);

			AudioManager.instance.PlayBGM(0);

            for (int i = 0; i < playerPositions.Length; i++)
            {
                if (GameManager.instance.PlayerStats[i].gameObject.activeInHierarchy)
                {
                    for (int j = 0; j < playerPrefabs.Length; j++)
                    {
						if(playerPrefabs[j].charName == GameManager.instance.PlayerStats[i].CharacterName)
                        {
							BattleChar newPlayer = Instantiate(playerPrefabs[j], playerPositions[i].position, playerPositions[i].rotation);
							newPlayer.transform.parent = playerPositions[i];
							activeBattlers.Add(newPlayer);
                        }
                    }
                }
            }
        }
    }
}
