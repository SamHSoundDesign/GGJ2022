using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFades : MonoBehaviour
{
    private string fadeInTrigger = "In";
    private string fadeOutTrigger = "Out";

    private bool fadedIn = true;

    private Animator anim;

    public void Setup()
    {
        anim = GetComponent<Animator>();
    }

    public void FadeIn()
    {
        AudioManager.instance.PlayAudioClip("Whoosh");
        anim.SetBool("FadeIn" , fadedIn);
        fadedIn = false;
    }

    public void FadeOut()
    {
        AudioManager.instance.PlayAudioClip("Whoosh");

        anim.SetBool("FadeIn", fadedIn);
        fadedIn = true;


    }
}
