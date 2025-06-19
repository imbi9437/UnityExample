using UnityEngine;

namespace _99_1.CustomShootingFish
{
    public class BaseBullet : Bullet
    {
        protected override void Move()
        {
            float speed = moveSpeed * Time.deltaTime;
            transform.Translate(transform.right * speed, Space.World);
        }

        protected override void Shoot()
        {
            
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
