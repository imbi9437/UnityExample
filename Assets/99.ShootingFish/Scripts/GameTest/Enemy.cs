using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _99.ShootingFishTest
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int hp;
        public float moveSpeed; //적들이 움직일 기본 속도
        public float turnInterval; //적들이 방향을 바꿀 주기
        private Vector2 moveDir; //적들이 움직일 방향
        private Rigidbody2D rigid;
        private SpriteRenderer renderer;

        private float lastTurnTime; //마지막으로 방향을 바꾼 시간

        private float effectTime;
        private bool isHit = false;

        private void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();
            renderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (Time.time > lastTurnTime + turnInterval)
            {
                //방향 바꿈
                moveDir = Random.insideUnitCircle;
                lastTurnTime = Time.time;

                rigid.linearVelocity = moveDir * moveSpeed;
            }

            if (isHit == false) return;

            effectTime += GameManager.Instance.effectSpeed * Time.deltaTime;
            renderer.color =
                GameManager.Instance.hitEffectGradient.Evaluate(effectTime);
            if (effectTime > 1)
            {
                isHit = false;
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.transform.GetComponent<Player>().Hit();
            }
        }

        public void Hit()
        {
            hp--;

            if (hp <= 0)
            {
                Destroy(gameObject);
                GameManager.Instance.player.AddExp();
                return;
            }

            isHit = true;
            effectTime = 0f;
        }
    }
}