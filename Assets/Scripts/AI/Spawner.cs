using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject player;
    [SerializeField] private Vector2 forcedSpawnLocation;
    [SerializeField] private bool random;

    private Vector2 spawnLocation;
    private GameObject[] EnemiesInScene;
    private int EnemiesInWorld = 0;
    private int EnemiesNeededInWorld;
    private float SpawnedX;
    private float SpawnedY;

    private Vector2 playerLocation;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        EnemiesInScene = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void Update()
    {
        EnemiesInScene = GameObject.FindGameObjectsWithTag("Enemy");
        spawnLocation = new Vector2(playerLocation.x * (Random.insideUnitCircle.x * Random.Range(-20f, 20f)), playerLocation.y * (Random.insideUnitCircle.y * Random.Range(-9f, 9f)));
        SetNewMaxSpawn();
    }

    private void FixedUpdate()
    {
        CheckSpawn();
    }

    public void OnSpawnPrefab()
    {
        if (player != null)
        {
            playerLocation = player.transform.position;
        }

        if (random)
        {
            SpawnedX = spawnLocation.x;
            SpawnedY = spawnLocation.y;

            if (SpawnedX != 0f)
            {
                if (SpawnedY != 0f)
                {
                    Instantiate(prefab, new Vector2(SpawnedX, SpawnedY), Quaternion.identity);
                }
            }
            //if ((SpawnedX < -(Screen.width) || SpawnedX > Screen.width) && (SpawnedY < -(Screen.height) || SpawnedY > Screen.height))
            //{
                
            //}
        }
        else
        {
            //debug
            Instantiate(prefab, forcedSpawnLocation, Quaternion.identity);
        }
    }

    private void CheckSpawn()
    {

        if (EnemiesInScene.Length <= EnemiesNeededInWorld)
        {
            OnSpawnPrefab();
        }
    }

    private void SetNewMaxSpawn()
    {
        if (EnemiesInWorld <= 0)
        {
            EnemiesNeededInWorld = Random.Range(1, 20);
        }
    }
}
