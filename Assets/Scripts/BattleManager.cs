using UnityEngine;

public class BattleManager : MonoBehaviour {

	public static BattleManager instance;

	private bool battleActive;

	public GameObject battleScene;

	public Transform[] playerPositions;
	public Transform[] enemyPositions;

	public BattleChar[] playerPrefabs;
	public BattleChar[] enemyPrefabs;

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
        }
    }
}
