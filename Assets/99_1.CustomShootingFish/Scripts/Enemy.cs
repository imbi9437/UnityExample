using UnityEngine;

namespace _99_1.CustomShootingFish
{
    public class Enemy : MonoBehaviour
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

        public void Hit()
        {
            hp--;

            if (hp <= 0)
            {
                _player.GetExp(Random.Range(0,9));
                Destroy(gameObject);
            }
        }
    }
}