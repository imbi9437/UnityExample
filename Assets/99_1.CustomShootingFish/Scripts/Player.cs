using System;
using System.Collections.Generic;
using System.Linq;
using Custom;
using UnityEngine;

namespace _99_1.CustomShootingFish
{
    public class Player : MonoBehaviour
    {
        public class Events
        {
            public Action OnHit;
            public Action OnDie;
            public Action OnGetExp;
            public Action OnLevelUp;
        }
        
        public static Events Subscribes = new Events();
        
        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rigidbody;
        
        private Transform weaponPivot;
        private SpriteRenderer weaponRenderer;

        [SerializeField] private List<Weapon> weapons;

        private int maxHp;
        private int hp;
        private int maxExp;
        private int exp;
        private int level;
        public float moveSpeed;
        
        
        //todo : Scheduler Event
        private bool canInputFire = true;
        private bool canAutoFire = true;

        private float lastInputFireTime = 0;
        private float lastAutoFireTime = 0;

        #region Unity Message Methods

        private void Awake()
        {
            _spriteRenderer = transform.Find("PlayerRenderer").GetComponent<SpriteRenderer>();
            _rigidbody = GetComponent<Rigidbody2D>();

            weaponPivot = transform.Find("WeaponPivot");
            weaponRenderer = weaponPivot.GetComponentInChildren<SpriteRenderer>();

            maxExp = 100;
        }

        private void OnEnable()
        {
            InputManager.Instance.OnFixedMove += MovePlayer;
            InputManager.Instance.OnMove += ChangeCharacterFlip;
            InputManager.Instance.OnMouseMove += ChangeWeaponFlip;

            InputManager.Instance.OnJump += InputFire;
            InputManager.Instance.OnFire1 += InputFire;
        }

        private void Update()
        {
            CheckAttackable();
        }
        
        private void OnDisable()
        {
            if (InputManager.Instance == null) return;
            
            InputManager.Instance.OnFixedMove -= MovePlayer;
            InputManager.Instance.OnMove -= ChangeCharacterFlip;
            InputManager.Instance.OnMouseMove -= ChangeWeaponFlip;

            InputManager.Instance.OnJump -= InputFire;
            InputManager.Instance.OnFire1 -= InputFire;
        }

        #endregion

        private void MovePlayer(Vector3 dir)
        {
            _rigidbody.linearVelocity = dir * moveSpeed;
        }
        
        private void ChangeCharacterFlip(Vector3 inputDir)
        {
            if (inputDir.x < 0) _spriteRenderer.flipX = true;
            else if (inputDir.x > 0) _spriteRenderer.flipX = false;
        }
        private void ChangeWeaponFlip(Vector3 mousePos)
        {
            Vector3 mouseDir = mousePos - transform.position;
            mouseDir = mouseDir.normalized;
            
            weaponPivot.right = mouseDir;
            weaponRenderer.flipY = mouseDir.x < 0;
        }

        
        //todo : Weapon으로 이전
        private void InputFire()
        {
            if (canInputFire == false) return;
            
            Fire(WeaponFireType.InputTrigger);
            canInputFire = false;
            lastInputFireTime = Time.time;
        }
        private void AutoFire()
        {
            if (canAutoFire == false) return;
            
            Fire(WeaponFireType.AutoFire);
            canAutoFire = false;
            lastAutoFireTime = Time.time;
        }
        private void Fire(WeaponFireType fireType)
        {
            foreach (var weapon in weapons)
            {
                if (weapon.FireType != fireType) continue;
                weapon.Fire();
            }
        }
        private void CheckAttackable()
        {
            if (canInputFire && canAutoFire) return;

            if (canInputFire == false)
            {
                float interval = GameManager.DefaultGameParam.PlayerInputFireInterval;
                if (Time.time >= lastInputFireTime + interval)
                {
                    canInputFire = true;
                }
            }

            if (canAutoFire == false)
            {
                float interval = GameManager.DefaultGameParam.PlayerAutoFireInterval;
                if (Time.time >= lastAutoFireTime + interval)
                {
                    canAutoFire = true;
                }
            }
        }
        
        

        public void Hit(int damage)
        {
            hp -= damage;
            
            Subscribes.OnHit?.Invoke();
            if (hp <= 0) Subscribes.OnDie?.Invoke();
        }

        public void GetExp(int exp)
        {
            this.exp += exp;
            
            Subscribes.OnGetExp?.Invoke();
            if (this.exp >= maxExp) LevelUp();
        }

        private void LevelUp()
        {
            exp = 0;
            level++;
            maxExp *= 2;
            
            Subscribes.OnLevelUp?.Invoke();
            if (level <= GameManager.DefaultGameParam.MaxForwardPivotCount)
                weapons[0].AddPivot();
        }
    }
}