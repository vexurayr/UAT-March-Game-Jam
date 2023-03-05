using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AudioManager : MonoBehaviour
{
    // Reference to itself to reach objects anywhere in the heiarchy
    public static AudioManager instance;

    public AudioClip playerShoot;

    private AudioSource audioPlayer;

    // Runs as soon as this object is enabled, one frame before Start()
    private void Awake()
    {
        // Only allows for one game manager, one singleton
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioPlayer = GetComponent<AudioSource>();
    }

    public void PlayPlayerShootSFX()
    {
        Debug.Log("Clip: " + playerShoot);
        audioPlayer.PlayOneShot(playerShoot);
    }
}