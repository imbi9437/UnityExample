using System;
using System.Collections.Generic;
using UnityEngine;
using Custom;

namespace _99.ShootingFishTest
{
    public class Player : MonoBehaviour
    {
        private SpriteRenderer characterRenderer;
        private Rigidbody2D rigid;
        private Vector3 mouseDir;

        private float effectTime;
        private bool isHit = false;

        public float bulletSpeed;
        public int maxHp = 100;
        public int hp;
        public float moveSpeed = 5f;
        public Bullet bullet;
        public int exp;
        public int maxExp;
        public int level;
        public float fireInterval = 1f;
        private float lastFireTime = 0;

        private int bulletCount = 1;

        public List<Transform> shotPoints;
        private Transform waeponPivot;

        public SpriteRenderer weaponRenderer;

        private void Awake()
        {
            characterRenderer = GetComponent<SpriteRenderer>();
            rigid = GetComponent<Rigidbody2D>();

            waeponPivot = transform.Find("GunPivot");
        }

        private void Start()
        {
            InputManager.Instance.OnMove += Move;
            InputManager.Instance.OnMove += ChangeCharacterFlip;

            InputManager.Instance.OnMouseMove += ChangeWeaponFlip;

            InputManager.Instance.OnJump += Fire;
            InputManager.Instance.OnFire1 += Fire;
            
            hp = maxHp;
            UIManager.Instance.hpGauge.fillAmount = 1;
            UIManager.Instance.expGauge.fillAmount = 0;
        }

        private void Update()
        {
            if (!isHit) return;

            effectTime += GameManager.Instance.effectSpeed * Time.deltaTime;
            characterRenderer.color = GameManager.Instance.hitEffectGradient.Evaluate(effectTime);
            if (effectTime > 1)
            {
                isHit = false;
            }
        }

        private void OnDestroy()
        {
            if (InputManager.Instance == null) return;
            InputManager.Instance.OnMove -= Move;
            InputManager.Instance.OnMove -= ChangeCharacterFlip;

            InputManager.Instance.OnMouseMove -= ChangeWeaponFlip;
            InputManager.Instance.OnJump -= Fire;
            InputManager.Instance.OnFire1 -= Fire;
        }

        private void Move(Vector3 dir)
        {
            rigid.linearVelocity = dir * moveSpeed;
        }

        private void ChangeCharacterFlip(Vector3 dir)
        {
            if (dir.x < 0) characterRenderer.flipX = true;
            else if (dir.x > 0) characterRenderer.flipX = false;
        }

        private void ChangeWeaponFlip(Vector3 pos)
        {
            mouseDir = pos - transform.position;
            mouseDir.Normalize();

            waeponPivot.right = mouseDir;
            weaponRenderer.flipY = mouseDir.x < 0;
        }

        private void Fire()
        {
            if (Time.time < lastFireTime + fireInterval) return;

            lastFireTime = Time.time;

            for (int i = 0; i < bulletCount; i++)
            {
                Bullet obj = Instantiate(bullet, shotPoints[i].position, shotPoints[i].rotation);
                obj.moveSpeed = bulletSpeed;
            }
        }

        public void Hit()
        {
            hp--;
            if (hp <= 0) Application.Quit();

            isHit = true;
            effectTime = 0f;
            
            UIManager.Instance.hpGauge.fillAmount = hp / (float) maxHp;
        }

        public void AddExp()
        {
            exp++;
            if (exp >= maxExp)
            {
                level++;
                maxExp *= 2;
                bulletCount = Mathf.Clamp(++bulletCount, 1, shotPoints.Count);
                exp = 0;
            }
            
            UIManager.Instance.expGauge.fillAmount = exp / (float) maxExp;
        }
    }
}