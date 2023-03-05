using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFile : MonoBehaviour
{
    public string fileName;

    private AudioSource audioPlayer;

    private void Awake()
    {
        audioPlayer = GetComponent<AudioSource>();
        audioPlayer.enabled = true;
    }

    public void PlaySound()
    {
        audioPlayer.loop = false;
        audioPlayer.PlayOneShot(audioPlayer.clip);
    }

    public void PlaySoundLooping()
    {
        audioPlayer.loop = true;
        audioPlayer.Play();
    }
}