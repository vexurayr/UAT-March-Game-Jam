using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator TransitionAnimator;
    public void PlayButton()
    {
        //SceneManager.LoadScene("Main");
        TransitionAnimator.SetTrigger("Fade");
        Debug.Log("ShouldAnimate");
    }
}
