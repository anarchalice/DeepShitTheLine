using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    //List of prefabs
    public GameObject[] levels; // Time in seconds between each spawn
    public float moveSpeed = 2f; // Speed at which the prefab moves downwards

    private float _nextSpawnTime;

    void Start()
    {
        Vector3 spawnPosition = transform.position - new Vector3(0, 24f, 0);
        GameObject newObject = Instantiate(levels[0], spawnPosition, Quaternion.identity);
        // Attach a script to move it downwards
        newObject.AddComponent<MoveDown>().SetSpeed(moveSpeed);
        newObject.AddComponent<DestroyAfterTime>();
        
        DontDestroyOnLoad(gameObject);
    }
    void Update()
    {
        // Check if it's time to spawn a new object
        if (Time.time >= _nextSpawnTime)
        {
            SpawnPrefab();
            _nextSpawnTime = Time.time + 24/moveSpeed;
        }
    }

    void SpawnPrefab()
    {
        // Instantiate the prefab at the generator's position
        GameObject newObject = Instantiate(levels[Random.Range(1,levels.Length)], transform.position, Quaternion.identity);
        // Attach a script to move it downwards
        newObject.AddComponent<MoveDown>().SetSpeed(moveSpeed);
        newObject.AddComponent<DestroyAfterTime>();
    }
}

public class MoveDown : MonoBehaviour
{
    public float speed;

    public void SetSpeed(float moveSpeed)
    {
        speed = moveSpeed;
    }

    void Update()
    {
        // Move the object down the Y-axis
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

public class DestroyAfterTime : MonoBehaviour
{
    public float time = 20;
    public float _awaitedTime = 0;

    

    void Update()
    {
        _awaitedTime += Time.deltaTime;
        
        if (_awaitedTime >= time)
            Destroy(gameObject);
    }
}