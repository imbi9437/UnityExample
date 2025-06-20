using System;
using UnityEngine;

namespace _10.LayerMask
{
    public class CameraMove : MonoBehaviour
    {
        public Transform target;    //따라다닐 대상
        private Vector3 offset;     //플레이어 기준으로 얼만큼 떨어져 있을지

        private void Start()
        {
            offset = transform.position - target.position;
        }

        private void LateUpdate()
        {
            transform.position = target.position + offset;
        }
    }
}
