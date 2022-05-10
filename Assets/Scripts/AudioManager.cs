using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioSource[] SFX;
    public AudioSource[] BGM;

    public static AudioManager instance;

    // Use this for initialization
    void Start()
    {
        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            PlaySfx(4);
            PlayBGM(3);
        }
    }

    public void PlaySfx(int soundToPlay)
    {
        if(soundToPlay < SFX.Length)
        {
            SFX[soundToPlay].Play();
        }
    }

    public void PlayBGM(int musicToPlay)
    {
        StopMusic();

        if(musicToPlay < BGM.Length)
        {
            BGM[musicToPlay].Play();
        }
    }
    
    public void StopMusic()
    {
        for (int i = 0; i < BGM.Length; i++)
        {
            BGM[i].Stop();
        }
    }
}
