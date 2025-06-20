using System;
using UnityEngine;

namespace SpaceShooter
{
    public class Projectile : MonoBehaviour
    {
        private float moveSpeed;
        private float damage;

        public void SetProjectile(float moveSpeed, float damage,float scaleFactor = 1f, float lifeTime = 4f)
        {
            this.moveSpeed = moveSpeed;
            this.damage = damage;
            transform.localScale = Vector3.one * scaleFactor;
            Destroy(gameObject, lifeTime);
        }

        private void Update()
        {
            transform.Translate(Vector3.up * (moveSpeed * Time.deltaTime));
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {   // 적에게 데미지를 주고 사라짐
                other.GetComponent<Enemy>().TakeDamage(damage);
                Destroy(gameObject);
            }
        }
    }
}