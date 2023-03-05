using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;

    public GameObject winScreen;

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

    public void LoadLevel()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadGameLevel()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Lose()
    {
        StartCoroutine(WaitFor(2));
    }

    public void WinScreen()
    {
        winScreen.SetActive(true);

        StartCoroutine(WaitFor(3));
    }

    public IEnumerator WaitFor(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        LoadMainMenu();
    }
}