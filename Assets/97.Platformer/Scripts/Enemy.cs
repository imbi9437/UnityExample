using System;
using UnityEngine;

namespace Platformer
{
    public class Enemy : MonoBehaviour
    {
        private SpriteRenderer renderer;
        private Player target;
        private float moveSpeed;

        private void Awake()
        {
            renderer = GetComponentInChildren<SpriteRenderer>();
        }

        private void Update()
        {
            Vector3 dir = target.transform.position - transform.position;
            dir.z = 0;
            dir = dir.normalized;
            
            Vector3 nextPos = transform.position + dir * (moveSpeed * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, nextPos, 0.9f);

            if (Mathf.Approximately(dir.x, 0f) == false)
            {
                renderer.flipY = dir.x < 0f;
            }
            transform.right = dir;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Player")) return;
            Rigidbody2D playerRigid = other.gameObject.GetComponent<Rigidbody2D>();
            Vector2 dir = other.gameObject.transform.position - transform.position;
            playerRigid.AddForce(dir.normalized * 20f, ForceMode2D.Impulse);
            GameManager.Instance.playerHitAction?.Invoke();
            Destroy(gameObject);
        }

        public void Init(Player target, float moveSpeed)
        {
            this.target = target;
            this.moveSpeed = moveSpeed;
        }
    }
}
