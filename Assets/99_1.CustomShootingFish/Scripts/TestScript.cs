using System;
using System.Collections.Generic;
using UnityEngine;

namespace _99_1.CustomShootingFish
{
    public class TestScript : MonoBehaviour
    {
        public int MaxCount;
        public Transform mainPivot;

        public List<Transform> bulletPivots;

        public GameObject pivotPrefab;
        public float pivotDistance;
        
        //함수 호출마다 총알 개수 늘어남
        private void AddBullet()
        {
            int pivotCount = bulletPivots.Count;
            
            float distance = (pivotCount - 1) * 0.5f * pivotDistance;
            
            float midY = mainPivot.localPosition.y;
            float leftY= midY + distance;
            float rightY = midY - distance;

            for (int i = 0; i < pivotCount; i++)
            {
                float count = Mathf.Max(1, pivotCount - 1);
                float adjust = Mathf.Lerp(leftY, rightY, i / count);
                Vector3 pos = mainPivot.localPosition + new Vector3(0,adjust, 0);
                
                bulletPivots[i].localPosition = pos;
            }
        }

        private void Update()
        {
        }
    }
}
