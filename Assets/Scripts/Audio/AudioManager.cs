using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public List<AudioFile> audioFiles;

    private AudioSource audioSoure;

    

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

        audioSoure = GetComponent<AudioSource>();
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
        AudioFile audioFile = FindAudioClip(clipID);

        if(audioFile == null)
        {
            Debug.Log("No audioFile with ID " + clipID + " has been found");
            return;
        }

        if (audioSoure.isPlaying != true)
        {
            if(audioFile.isOneShot)
            {
                audioSoure.PlayOneShot(audioFile.audioClip);
            }
        }
        else
        {
            Debug.Log("Audio Source is already playing. Audio Clip name is " + audioSoure.clip.name);
        }
    }
}
