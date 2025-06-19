using System;
using UnityEngine;

namespace _99.ShootingFishTest
{
    public class Rotater : MonoBehaviour
    {
        [Tooltip("초당 회전 각도")] public Vector3 rotateAxis;

        private void Update()
        {
            transform.Rotate(rotateAxis * Time.deltaTime);
        }
    }
}