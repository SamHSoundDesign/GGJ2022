using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip music;
    public AudioSource audioSource;
    public float musicVolume;

    private void Start()
    {
        StartMusic();
    }
    public void StartMusic()
    {
        audioSource.clip = music;
        audioSource.loop = true;
        audioSource.volume = musicVolume;
        audioSource.Play();
    }
}
