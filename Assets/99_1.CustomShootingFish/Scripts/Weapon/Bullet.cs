using System;
using UnityEngine;

namespace _99_1.CustomShootingFish
{
    public abstract class Bullet : MonoBehaviour
    {
        protected float moveSpeed;
        private void Start()
        {
            InitBullet(5);//임시용
            Destroy(gameObject, 10f);
        }

        private void Update()
        {
            Move();
        }

        protected abstract void Move();
        protected abstract void Shoot();
        
        public void InitBullet(float speed) => moveSpeed = speed;
    }
}
