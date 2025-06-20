using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _99_1.CustomShootingFish
{
    public class Enemy : MonoBehaviour, IHitAble
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public int hp;
        public float moveSpeed;
        private Vector3 moveDir;
    
        private Player _player => GameManager.Instance.player;

        private void Update()
        {
            moveDir = _player.transform.position - transform.position;
            moveDir.z = 0;
            moveDir = moveDir.normalized;
        }

        private void FixedUpdate()
        {
            _rigidbody.linearVelocity = moveDir * moveSpeed;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out IHitAble hitAble) == false) return;
            
        }
        
        public void Hit(int damage)
        {
            hp -= damage;
            
            if (hp <= 0) Die();
        }

        public void Die()
        {
            _player.GetExp(Random.Range(0,9));
            Destroy(gameObject);
        }
    }
}