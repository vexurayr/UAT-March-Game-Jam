using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameObject winScreen;

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