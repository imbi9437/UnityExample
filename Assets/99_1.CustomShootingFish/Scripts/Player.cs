using System;
using System.Collections.Generic;
using System.Linq;
using Custom;
using UnityEngine;

namespace _99_1.CustomShootingFish
{
    public class Player : MonoBehaviour, IHitAble
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
        
        
        private void InputFire() => Fire(WeaponFireType.InputTrigger);
        private void AutoFire() => Fire(WeaponFireType.AutoFire);
        private void Fire(WeaponFireType fireType)
        {
            foreach (var weapon in weapons)
            {
                if (weapon.FireType != fireType) continue;
                weapon.Fire();
            }
        }

        public void Hit(int damage)
        {
            hp -= damage;
            
            Subscribes.OnHit?.Invoke();
            if (hp <= 0) Die();
        }
        public void Die()
        {
            Subscribes.OnDie?.Invoke();
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