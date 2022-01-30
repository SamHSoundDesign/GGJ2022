using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFades : MonoBehaviour
{
    private string fadeInTrigger = "In";
    private string fadeOutTrigger = "Out";

    private bool fadedIn = false;

    private Animator anim;

    public void Setup()
    {
        anim = GetComponent<Animator>();
    }

    public void FadeIn()
    {
        fadedIn = false;

        if(AudioManager.instance != null)
        {
            AudioManager.instance.PlayAudioClip("Whoosh");

        }
        anim.SetBool("FadeIn" , !fadedIn);
    }

    public void FadeOut()
    {
        fadedIn = true;
        AudioManager.instance.PlayAudioClip("Whoosh");

        anim.SetBool("FadeIn", !fadedIn);


    }
}
