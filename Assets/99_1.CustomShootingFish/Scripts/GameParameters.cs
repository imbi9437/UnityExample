using System;
using UnityEngine;

namespace _99_1.CustomShootingFish
{
    [Serializable]
    public class GameParameters
    {
        public int MaxForwardPivotCount = 5;
        public float PlayerInputFireInterval = 0.2f;
        public float PlayerAutoFireInterval = 1f;
    }
}
