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
            CheckCanJump();
            if (Input.GetButtonDown("Jump")) Jump();
        }

        private void Move()
        {
            float x = Input.GetAxis("Horizontal");
            
            rb.AddForceX(x * moveSpeed);
            
            //실수의 ==를 연산할 때 안전한 함수
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
            canJump = false;
        }

        private void CheckCanJump()
        {
            Vector2 startPos = col.bounds.center;
            startPos.y -= col.bounds.extents.y;
            int mask = LayerMask.GetMask("Ground");
            canJump = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0, Vector2.down, 0.1f, mask);
            ani.SetBool(IsJumping, canJump == false);
        }
    }
}