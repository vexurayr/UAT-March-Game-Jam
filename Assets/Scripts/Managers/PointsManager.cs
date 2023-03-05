using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    public static PointsManager instance;

    public LevelLoader levelLoader;

    public GameObject scoreUI;
    public int startingScore;

    private Text scoreText;
    private int currentScore;

    private void Awake()
    {
        // Only allows for one points manager
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

    // Start is called before the first frame update
    void Start()
    {
        scoreText = scoreUI.gameObject.GetComponent<Text>();
        currentScore = startingScore;

        scoreText.text = currentScore.ToString();
    }

    //Reset is called every time a new round starts
    public void Reset()
    {
        currentScore = 0;

        scoreText.text = currentScore.ToString();
    }

    public int GetPlayerScore()
    {
        return currentScore;
    }

    public void SetPlayerScore(int newScore)
    {
        currentScore = newScore;

        scoreText.text = currentScore.ToString();

        if (currentScore >= 1000)
        {
            levelLoader.WinScreen();
        }
    }
}