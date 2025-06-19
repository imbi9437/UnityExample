using System.Collections.Generic;
using UnityEngine;

namespace _99.ShootingFishTest
{
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
                spawnPosition += GameManager.Instance.player.transform.position;
                Instantiate(enemy, spawnPosition, Quaternion.identity);

                lastSpawnTime = Time.time;
            }
        }
    }
}