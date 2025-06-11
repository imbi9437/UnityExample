using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> Enemy;
    public float interval;
    private float lastSpawnTime;
    
    void Update()
    {
        if (Time.time > interval + lastSpawnTime)
        {
            GameObject enemy = Enemy[Random.Range(0, Enemy.Count)];
            Vector3 spawnPosition = Random.insideUnitCircle * 5;
            Instantiate(enemy, spawnPosition, Quaternion.identity);
            
            lastSpawnTime = Time.time;
        }
    }
}
