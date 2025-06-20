using System.Collections.Generic;
using UnityEngine;

namespace _99_1.CustomShootingFish
{
    public enum WeaponFireType
    {
        InputTrigger,
        AutoFire,
    }
    
    public abstract class Weapon : MonoBehaviour
    {
        public abstract WeaponFireType FireType { get; }

        protected Transform mainPivot;
        protected List<Transform> pivots;
        public Bullet bulletPrefab;

        protected float lastFireTime;
        protected float interval;
        protected abstract float AdjustInterval { get; }

        public abstract void Fire();
        public abstract void AddPivot();

        private void Awake()
        {
            mainPivot = transform.Find("MainPivot");
            pivots = new List<Transform>();
            AddPivot();

            lastFireTime = 0;
            interval = 0.1f;
        }
    }
}
