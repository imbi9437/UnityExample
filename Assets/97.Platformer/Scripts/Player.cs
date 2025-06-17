using System;
using UnityEngine;

namespace Platformer
{
    public class Player : MonoBehaviour
    {
        private static readonly int IsWalking = Animator.StringToHash("IsMove");
        private static readonly int IsJumping = Animator.StringToHash("IsJump");
        
        public float moveSpeed;
        public float jumpForce;
        
        private Rigidbody2D rb;
        private Collider2D col;
        private Animator ani;
        
        [SerializeField]private SpriteRenderer sr;

        private bool canJump = false;
        
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            col = GetComponent<Collider2D>();
            ani = GetComponent<Animator>();
            if (sr == false)
                sr = GetComponentInChildren<SpriteRenderer>();
        }

        private void Update()
        {
            Move();
            if (Input.GetButtonDown("Jump")) Jump();
        }

        private void Move()
        {
            float x = Input.GetAxis("Horizontal");
            
            
            rb.linearVelocity = new Vector2(x * moveSpeed, rb.linearVelocity.y);
            //rb.AddForceX(x * moveSpeed);
            
            if (Mathf.Approximately(x, 0f) == false)
            {
                sr.flipX = x < 0f;
                ani.SetBool(IsWalking, true);
            }
            else
            {
                ani.SetBool(IsWalking, false);
            }
        }

        private void Jump()
        {
            if (canJump == false) return;
            rb.AddForceY(jumpForce, ForceMode2D.Impulse);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Ground")) return;
            canJump = true;
            ani.SetBool(IsJumping, false);
        }
        
        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Ground")) return;
            canJump = false;
            ani.SetBool(IsJumping, true);
        }
    }
}