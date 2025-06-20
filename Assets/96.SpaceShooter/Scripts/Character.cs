using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Character : MonoBehaviour
    {
        public float moveSpeed;
        public float maxHp;
        protected float currentHp;
        
        public SpriteRenderer spriteRenderer;
        protected  Rigidbody2D rb;

        protected virtual void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        
        protected abstract void Move(Vector3 pos);

        public virtual void TakeDamage(float damage)
        {
            currentHp -= damage;

            if (currentHp <= 0) Die();
        }

        protected abstract void Die();
    }
}