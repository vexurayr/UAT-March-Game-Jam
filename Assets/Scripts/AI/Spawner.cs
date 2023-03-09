using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int poolSize = 10;
    [SerializeField] private string poolName;
    [SerializeField] private bool poolCanExpand = true;

    private GameObject player;
    private List<GameObject> pooledObjects;
    private GameObject parentObject;
    private float spawnDistance;
    private Vector2 spawnLocation;
    private float spawnTimer;

    public Vector3 EnemySpawnPosition { get; set; }

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        parentObject = new GameObject(name: poolName);
        Refill();
    }

    private void Update()
    {
        spawnTimer += 0.5f;

        if (spawnTimer > 2)
        {
            EvaluateEnemySpawnPosition();
            spawnDistance = Vector2.Distance(EnemySpawnPosition, player.transform.position);

            if (spawnDistance >= 15)
            {
                SpawnEnemy(EnemySpawnPosition);
            }
            spawnTimer = 0;
        }
    }

    public void Refill()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            AddObjectToPool();
        }
    }

    public GameObject GetObjectFromPool()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        if (poolCanExpand)
        {
            return AddObjectToPool();
        }

        return null;
    }

    public GameObject AddObjectToPool()
    {
        GameObject newObject = Instantiate(objectPrefab);
        newObject.SetActive(false);
        newObject.transform.parent = parentObject.transform;

        pooledObjects.Add(newObject);
        return newObject;
    }

    private void SpawnEnemy(Vector2 spawnPosition)
    {
        //Get Obj from pool
        GameObject EnemyPooled = GetObjectFromPool();
        EnemyPooled.transform.position = spawnPosition;
        EnemyPooled.SetActive(true);
    }

    private void EvaluateEnemySpawnPosition()
    {
        EnemySpawnPosition = new Vector2(player.transform.position.x + (Random.insideUnitCircle.x * Random.Range(-20f, 20f)), (Random.insideUnitCircle.y * Random.Range(-9f, 9f)));
    }
}
