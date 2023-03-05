using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AudioManager : MonoBehaviour
{
    // Reference to itself to reach objects anywhere in the heiarchy
    public static AudioManager instance;

    public List<AudioFile> audioFiles;

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
    }

    public void PlaySound(string fileName)
    {
        foreach (AudioFile file in audioFiles)
        {
            if (fileName == file.fileName)
            {
                file.PlaySound();
                return;
            }
        }
    }

    public void PlaySoundLooping(string fileName)
    {
        foreach (AudioFile file in audioFiles)
        {
            if (fileName == file.fileName)
            {
                file.PlaySoundLooping();
                return;
            }
        }
    }
}