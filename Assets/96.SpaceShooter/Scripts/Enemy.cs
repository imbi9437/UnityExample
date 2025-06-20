using System;
using UnityEngine;

namespace SpaceShooter
{
    public class Enemy : Character
    {
        public int score = 1;
        protected override void Move(Vector3 pos)
        {   //밑으로 내려가도록
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);

            rb.MovePosition(rb.position + Vector2.down * moveSpeed * Time.fixedDeltaTime);
        }

        protected override void Die()
        {
            Player.score += score;
            
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            
        }
    }
}