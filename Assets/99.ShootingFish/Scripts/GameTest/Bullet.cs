using System;
using UnityEngine;

namespace _99.ShootingFishTest
{
    public class Bullet : MonoBehaviour
    {
        private bool isCurved = false;

        public float moveSpeed;

        private void Start()
        {
            Destroy(gameObject, 10f);
        }

        private void Update()
        {
            Vector3 dir = transform.right * moveSpeed;

            if (true)
            {
                float a = Mathf.Cos(Time.time * moveSpeed);
                dir.y += a * moveSpeed;
                transform.Rotate(0, 0, a);
            }

            transform.Translate(transform.right * (moveSpeed * Time.deltaTime), Space.World);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player")) return;

            Destroy(gameObject);

            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<Enemy>().Hit();
            }
        }
    }
}