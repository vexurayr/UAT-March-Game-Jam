using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Reference to itself to reach objects anywhere in the heiarchy
    public static GameManager instance;

    // Things the game manager will need to reference
    public GameObject m_PlayerControllerPrefab;
    public GameObject m_SoldierPawnPrefab;
    public Transform m_PlayerSpawnTransform;
    public List<PlayerController> m_Players;
    private GameObject m_NewPawnObject;

    // Runs as soon as this object is enabled, one frame before Start()
    private void Awake()
    {
        m_Players = new List<PlayerController>();

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

    void Start()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        // Spawns player controller into the scene
        GameObject newPlayerObject = Instantiate(m_PlayerControllerPrefab, Vector3.zero, Quaternion.identity);
        m_NewPawnObject = Instantiate(m_SoldierPawnPrefab, m_PlayerSpawnTransform.position, m_PlayerSpawnTransform.rotation);

        Controller newController = newPlayerObject.GetComponent<Controller>();
        Pawn newPawn = m_NewPawnObject.GetComponent<Pawn>();

        newController.m_Pawn = newPawn;
    }
}