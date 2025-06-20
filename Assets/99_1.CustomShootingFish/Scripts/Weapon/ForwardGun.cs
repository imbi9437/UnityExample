using UnityEngine;

namespace _99_1.CustomShootingFish
{
    public class ForwardGun : Weapon
    {
        public override WeaponFireType FireType => WeaponFireType.InputTrigger;
        protected override float AdjustInterval => GameManager.DefaultGameParam.PlayerInputFireInterval; 
        
        //todo : 해당 변수 위치 이동 필요할 듯
        public float pivotDistance = 0.1f;
        
        public override void Fire()
        {
            float calcInterval = interval + AdjustInterval;
            if (Time.time <= lastFireTime + calcInterval) return;
            foreach (Transform pivot in pivots)
            {
                Instantiate(bulletPrefab, pivot.position, pivot.rotation);
            }
            
            lastFireTime = Time.time;
        }

        public override void AddPivot()
        {
            var pivot = new GameObject("Pivot");
            pivot.transform.SetParent(transform);
            pivot.transform.localPosition = Vector3.zero;
            pivot.transform.localRotation = Quaternion.identity;
            pivots.Add(pivot.transform);
            
            int pivotCount = pivots.Count;
        
            float distance = (pivotCount - 1) * 0.5f * pivotDistance;

            float midY = mainPivot.localPosition.y;
            float leftY= midY + distance;
            float rightY = midY - distance;

            for (int i = 0; i < pivotCount; i++)
            {
                float count = Mathf.Max(1, pivotCount - 1);
                float adjust = Mathf.Lerp(leftY, rightY, i / count);
                Vector3 pos = mainPivot.localPosition + new Vector3(0,adjust, 0);
            
                pivots[i].localPosition = pos;
            }
        }
    }
}
