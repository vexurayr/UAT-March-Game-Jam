using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraManager : MonoBehaviour
{
    public static PlayerCameraManager instance;

    private PlayerController playerController;
    private Pawn player;

    private void Awake()
    {
        // Only allows for one game manager, one singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController != null)
        {
            Camera.main.transform.position = new Vector3(player.transform.position.x, Camera.main.transform.position.y,
                Camera.main.transform.position.z);
        }
    }

    public void AssignPlayerController(PlayerController controller)
    {
        playerController = controller;
        player = playerController.m_Pawn;
    }
}