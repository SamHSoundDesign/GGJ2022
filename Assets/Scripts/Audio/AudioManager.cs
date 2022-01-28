using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<AudioFiles> audioFiles;

    private AudioSource audioSoure;

    private void Start()
    {
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


    public AudioFiles FindAudioClip(string clipID)
    {
        AudioFiles audioFile = null;

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
        AudioFiles audioFile = FindAudioClip(clipID);

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
