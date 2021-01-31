using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTransition : MonoBehaviour
{
    public AudioSource source;
    public AudioClip intenseTrack;

    public AudioClip gamasTrack;

    public AudioClip defaultTrack;

    public AudioClip endingTrack;

    public void PlayIntenseTrack() {
        source.clip = intenseTrack;
        source.Play();
    }

    public void PlayGamasTrack() {
        source.clip = gamasTrack;
        source.Play();
    }

    public void PlayDefault() {
        source.clip = defaultTrack;
        source.Play();
    }

    public void PlayEndingTrack() {
        source.clip = endingTrack;
        source.Play();
    }
}
