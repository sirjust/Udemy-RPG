using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour {

	public string AreaToLoad;

	public string AreaTransitionName;

	public AreaEntrance Entrance;

	public float WaitToLoad = 1f;
	private bool ShouldLoadAfterFade;

	// Use this for initialization
	void Start () {
		Entrance.TransitionName = AreaTransitionName;
	}
	
	// Update is called once per frame
	void Update () {
		if(ShouldLoadAfterFade == true)
        {
			WaitToLoad -= Time.deltaTime;
			if (WaitToLoad <= 0)
            {
				ShouldLoadAfterFade = false;
				SceneManager.LoadScene(AreaToLoad);
            }
        }
	}

	private void OnTriggerEnter2D(Collider2D other)
    {
		if(other.tag == "Player")
        {
			ShouldLoadAfterFade = true;
			UIFade.instance.FadeToBlack();

			PlayerController.instance.AreaTransitionName = AreaTransitionName;
        }
    }
}
