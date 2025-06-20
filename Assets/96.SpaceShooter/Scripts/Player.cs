using System;
using Custom;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShooter
{   
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : Character, IBuff
    {
        public static int score;
        
        private AudioSource audioSource;
        private Projectile projectilePrefab;
        private Transform shotPoint;

        public AudioClip fireSound;
        
        public float shotSpeed;
        public float shotDamage;
        
        private float chargingTime;
        
        protected override void Awake()
        {
            base.Awake();
            projectilePrefab = Resources.Load<Projectile>("Projectile");
            shotPoint = transform.Find("ShotPoint");
            audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            InputManager.Instance.OnMove += Move;

            InputManager.Instance.OnFire1 += Charging;
            InputManager.Instance.OnFire1Up += Fire;
        }

        private void OnDisable()
        {
            InputManager.Instance.OnMove -= Move;
            
            InputManager.Instance.OnFire1 -= Charging;
            InputManager.Instance.OnFire1Up -= Fire;
        }

        protected override void Move(Vector3 pos)
        {
            Vector2 dir = Vector2.ClampMagnitude(new Vector2(pos.x, pos.y), 1);
            rb.MovePosition(rb.position + dir * (moveSpeed * Time.fixedDeltaTime));
        }

        protected override void Die()
        {
            SceneManager.LoadScene("SpaceShooterEnd");
        }

        private void Fire()
        {
            float adjustScale = chargingTime < 1f ? 1 : (int)chargingTime * 3f;
            float adjustDamage = (int)chargingTime * 2f;
            float calcDamage = shotDamage + adjustDamage;
            Projectile proj = Instantiate(projectilePrefab,shotPoint.position,shotPoint.rotation);
            proj.SetProjectile(shotSpeed, calcDamage,adjustScale);
            chargingTime = 0f;
            
            //발사음 재생
            audioSource.PlayOneShot(fireSound);
        }

        
        //todo : MAX값 설정 및 차징 이펙트 추가
        private void Charging() => chargingTime += Time.deltaTime;

        public void Buff(BuffType type, float value)
        {
            switch (type)
            {
                case BuffType.MoveSpeed:
                    moveSpeed += value;
                    break;
                case BuffType.AttackInterval:
                    //todo : Interval 기능 추가
                    break;
                case BuffType.Damage:
                    shotDamage += value;
                    break;
                case BuffType.Heal:
                    currentHp = Mathf.Min(currentHp + value, maxHp);
                    break;
                case BuffType.None:
                default:
                    break;
            }
        }
    }
}
