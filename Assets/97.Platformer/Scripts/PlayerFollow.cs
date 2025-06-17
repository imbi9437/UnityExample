using System;
using UnityEngine;

namespace Platformer
{
    public class PlayerFollow : MonoBehaviour
    {
        private static readonly int IsShake = Animator.StringToHash("IsShake");
        
        private Animator animator;
        private Vector3 nextPos;
        
        
        private Player Player => GameManager.Instance.player;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
            GameManager.Instance.playerHitAction += Shake;
        }

        private void FixedUpdate()
        {
            FollowPlayer();
        }

        private void FollowPlayer()
        {
            nextPos = Player.transform.position;
            nextPos.z = transform.position.z;

            transform.position = Vector3.Lerp(transform.position, nextPos, 0.1f);
        }
        
        private void OnDestroy()
        {
            if (GameManager.Instance == null) return;
            GameManager.Instance.playerHitAction -= Shake;
        }

        private void Shake()
        {
            animator.SetBool(IsShake, true);
        }
    }
}