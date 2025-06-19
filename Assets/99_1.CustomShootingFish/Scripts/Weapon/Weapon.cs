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

        public abstract void Fire();
        public abstract void AddPivot();

        private void Awake()
        {
            mainPivot = transform.Find("MainPivot");
            pivots = new List<Transform>();
            AddPivot();
        }
    }
}
