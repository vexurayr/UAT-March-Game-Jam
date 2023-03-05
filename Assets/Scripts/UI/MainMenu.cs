using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transitionAnimator;

    public void PlayButton()
    {
        transitionAnimator.SetTrigger("Fade");
        SceneManager.LoadScene("Main");
        Debug.Log("ShouldAnimate");
    }
}
