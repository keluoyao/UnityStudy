using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager Instance;
    public AudioSource bgPlayer;
    public AudioSource sePlayer;
    void Awake()
    {
        Instance = this;
    }
    public void PlayMusic(string name)
    {
        if (bgPlayer.isPlaying == false)
        {
            AudioClip clip = Resources.Load<AudioClip>(name);
            bgPlayer.clip = clip;
            bgPlayer.Play();
        }
    }
    public void StopMusic()
    {
        bgPlayer.Stop();
    }
    public void PlaySound(string name)
    {
        AudioClip clip = Resources.Load<AudioClip>(name);
        sePlayer.PlayOneShot(clip);
    }


}
