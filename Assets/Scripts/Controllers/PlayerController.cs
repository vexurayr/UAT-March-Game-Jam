using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Allows objects of this class to appear in the editor
[System.Serializable]
public class PlayerController : Controller
{
    public float maxVerticalMovement;

    // Creates a new field representing a button that can be set in the editor
    public KeyCode m_KeyForward = KeyCode.W;
    public KeyCode m_KeyBackward = KeyCode.S;
    public KeyCode m_KeyLeft = KeyCode.A;
    public KeyCode m_KeyRight = KeyCode.D;
    public KeyCode m_ShootKey = KeyCode.Mouse0; // Left-click

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        // Adds itself to the game manager
        if (GameManager.instance != null && GameManager.instance.m_Players != null)
        {
            GameManager.instance.m_Players.Add(this);
            PlayerCameraManager.instance.AssignPlayerController(this);
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        ProcessInputs();
    }

    // Built in function runs when objects is destroyed

    public void OnDestroy()
    {
        // Instance of player controller in list already exists
        if (GameManager.instance != null && GameManager.instance.m_Players != null)
        {
            GameManager.instance.m_Players.Remove(this);
        }
    }

    // Function that uses the keycodes to access the pawn referrence in the parent class
    // to run the functions in the TankPawn class
    public override void ProcessInputs()
    {
        // Get Key runs as long as it's held, Get Key Down runs once on being pressed, Get Key Up runs once on being released
        if (Input.GetKey(m_KeyForward) && m_Pawn.transform.position.y < maxVerticalMovement)
        {
            // Tells the pawn attached to this script to move forward
            m_Pawn.MoveForward();
        }
        if (Input.GetKey(m_KeyBackward) && m_Pawn.transform.position.y > -maxVerticalMovement)
        {
            m_Pawn.MoveBackward();
        }
        if (Input.GetKey(m_KeyLeft))
        {
            m_Pawn.MoveLeft();
        }
        if (Input.GetKey(m_KeyRight))
        {
            m_Pawn.MoveRight();
        }

        if (Input.GetKey(m_ShootKey))
        {
            // Calls the Shoot function in the Pawn class
            m_Pawn.Shoot();
        }
    }
}