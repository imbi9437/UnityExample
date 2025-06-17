using System;
using System.Collections;
using UnityEngine;

namespace _07.AnimationTest
{
    public class AnimationControlTest : MonoBehaviour
    {
        public static readonly int IsMoving = Animator.StringToHash("IsMoving");
        public static readonly int IsJumping = Animator.StringToHash("IsJumping");
        public static readonly int Horizontal = Animator.StringToHash("Horizontal");
        public static readonly int Hit = Animator.StringToHash("Hit");
        
        private Animator animator;
        private SpriteRenderer sp;

        public float moveSpeed;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            sp = GetComponentInChildren<SpriteRenderer>();
        }

        private void Update()
        {
            float x = Input.GetAxis("Horizontal");
            transform.Translate(x * moveSpeed * Time.deltaTime, 0, 0);
            bool isMoving = Mathf.Approximately(x, 0f) == false;
            
            
            animator.SetFloat(Horizontal,Mathf.Abs(x));
            //animator.SetBool(IsMoving,isMoving);

            if (isMoving)
            {
                sp.flipX = x < 0;
            }

            bool isJumping = Input.GetButton("Jump");
            
            animator.SetBool(IsJumping,isJumping);
            
            if (Input.GetButtonDown("Fire1")) animator.SetTrigger(Hit);
        }
    }
}
