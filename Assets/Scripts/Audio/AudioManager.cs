using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public List<AudioFile> audioFiles;

    public List<AudioSource> audioSoure;

    private float hoverOverTimerAmout = 0.15f;
    private float nextTimeHoverOverCanPlay = 0;

    

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    public void PlayAudioEvent(AudioEvents audioEvent)
    {
        switch (audioEvent)
        {
            case AudioEvents.LevelStart:

                break;
            case AudioEvents.LevelEnd:

                break;
            case AudioEvents.PauseMenuOpen:

                break;
            case AudioEvents.PauseMenuClose:

                break;
        }
    }
    public AudioFile FindAudioClip(string clipID)
    {
        AudioFile audioFile = null;

        if(audioFiles.Count == 0)
        {
            Debug.Log("AudioManager : List of audio files is empty");
            return null;
        }

        for (int i = 0; i < audioFiles.Count; i++)
        {
            if (audioFiles[i].clipID == clipID)
            {
                audioFile = audioFiles[i];
                break;
            }
        }

        if (audioFile != null)
        {
            return audioFile;
        }
        else
        {
            return null;
        }
    }
    public void PlayAudioClip(string clipID)
    {
        if(clipID == "MouseHover")
        {
            if (Time.time < nextTimeHoverOverCanPlay)
            {
                Debug.Log("Too soon since last MouseHover sfx");
                return;
            }
            else
            {
                StartTimer();
            }
        }

        AudioFile audioFile = FindAudioClip(clipID);

        if(audioFile == null)
        {
            Debug.Log("No audioFile with ID " + clipID + " has been found");
            return;
        }

        AudioSource source = GetAvailableAudioSource();

        if(source == null)
        {
            return;
        }
       
        if(audioFile.isOneShot)
        {
            source.volume = audioFile.volume;
            source.PlayOneShot(audioFile.audioClip);
        }
        
        
    }
    public void StartTimer()
    {
        nextTimeHoverOverCanPlay = Time.time + hoverOverTimerAmout;
    }

    public AudioSource GetAvailableAudioSource()
    {
        AudioSource source = null;

        for (int i = 0; i < audioSoure.Count; i++)
        {
            if(audioSoure[i].isPlaying != true)
            {
                return audioSoure[i];
            }
        }

        return source;


    }

}
