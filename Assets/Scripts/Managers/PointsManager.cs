using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public static PointsManager instance;

    private int sceneStartScore;
    public int playerScore;

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
        playerScore = 0;
    }

    //Reset is called every time a new round starts
    void Reset()
    {
        playerScore = sceneStartScore;
    }

    public int GetPlayerScore()
    {
        return playerScore;
    }

    public void SetPlayerScore(int newScore)
    {
        playerScore = newScore;
    }
}