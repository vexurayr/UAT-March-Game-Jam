using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

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

    // For infinite background
    public List<GameObject> backgrounds;
    public float backgroundSize;

    // To mess with global lighting
    public Light2D sunlight;
    public float decMult;

    // Runs as soon as this object is enabled, one frame before Start()
    private void Awake()
    {
        m_Players = new List<PlayerController>();

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

        SpawnPlayer();
    }

    private void Update()
    {
        CheckPlayerDistances();

        sunlight.intensity -= (decMult * Time.deltaTime);
        sunlight.intensity = Mathf.Clamp(sunlight.intensity, 0f, 1f);
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

    public void CheckPlayerDistances()
    {
        Vector2 distanceToFirstBorder = backgrounds[0].GetComponent<Background>().verticalBorder.transform.position -
            m_Players[0].m_Pawn.transform.position;
        Vector2 distanceToSecondBorder = backgrounds[1].GetComponent<Background>().verticalBorder.transform.position -
            m_Players[0].m_Pawn.transform.position;

        if (distanceToSecondBorder.x >= backgroundSize && distanceToFirstBorder.x > 0)
        {
            backgrounds[1].transform.position = new Vector2(backgrounds[1].transform.position.x - (backgroundSize * 2),
                backgrounds[1].transform.position.y);

            GameObject temp = backgrounds[0];
            backgrounds[0] = backgrounds[1];
            backgrounds[1] = temp;
        }
        else if (distanceToSecondBorder.x < 0 && distanceToFirstBorder.x <= -backgroundSize)
        {
            backgrounds[0].transform.position = new Vector2(backgrounds[0].transform.position.x + (backgroundSize * 2),
                backgrounds[0].transform.position.y);

            GameObject temp = backgrounds[0];
            backgrounds[0] = backgrounds[1];
            backgrounds[1] = temp;
        }
    }
}