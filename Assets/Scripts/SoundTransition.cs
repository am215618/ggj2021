using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTransition : MonoBehaviour
{
    public AudioSource source;
    public AudioClip audioClip;
    public AudioClip ogaudioClip;

    public void ChangeSong()
    {
        source.clip = audioClip;
        source.Play();
    }
}
