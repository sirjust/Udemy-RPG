using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour {

	public static UIFade instance;

	public Image FadeScreen;
	public float FadeSpeed;

	public bool ShouldFadeToBlack;
	public bool ShouldFadeFromBlack;


	// Use this for initialization
	void Start () {
		instance = this;

		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		if (ShouldFadeToBlack)
		{
			FadeScreen.color = new Color(FadeScreen.color.r, FadeScreen.color.g, FadeScreen.color.b, Mathf.MoveTowards(FadeScreen.color.a, 1f, FadeSpeed * Time.deltaTime));
			if(FadeScreen.color.a == 1f) ShouldFadeToBlack = false;
		}

		if (ShouldFadeFromBlack)
		{
			FadeScreen.color = new Color(FadeScreen.color.r, FadeScreen.color.g, FadeScreen.color.b, Mathf.MoveTowards(FadeScreen.color.a, 0f, FadeSpeed * Time.deltaTime));
			if(FadeScreen.color.a == 0) ShouldFadeFromBlack = false;
		}
	}

	public void FadeToBlack()
    {
		ShouldFadeToBlack = true;
		ShouldFadeFromBlack = false;
    }

	public void FadeFromBlack()
    {
		ShouldFadeFromBlack = true;
		ShouldFadeToBlack = false;
    }
}
