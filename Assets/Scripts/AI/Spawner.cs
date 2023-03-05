using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Character player;
    [SerializeField] private Vector2 forcedSpawnLocation;
    [SerializeField] private bool random;

    private Vector2 spawnLocation;
    private int EnemiesInWorld = 0;
    private int EnemiesNeededInWorld;
    private float SpawnedX;
    private float SpawnedY;

    private Vector2 playerLocation;

    private void Update()
    {
        SetNewMaxSpawn();
        spawnLocation = new Vector2(playerLocation.x * (Random.insideUnitCircle.x * Random.Range(150f, 200f)), playerLocation.y * (Random.insideUnitCircle.y * Random.Range(150f, 200f)));
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

            //if ((SpawnedX < -(Screen.width) || SpawnedX > Screen.width) && (SpawnedY < -(Screen.height) || SpawnedY > Screen.height))
            //{
                Instantiate(prefab, new Vector2(SpawnedX, SpawnedY), Quaternion.identity);
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
        if (EnemiesInWorld < EnemiesNeededInWorld)
        {
            for (EnemiesInWorld = 0; EnemiesInWorld < EnemiesNeededInWorld; EnemiesInWorld++)
            {
                OnSpawnPrefab();
            }
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
