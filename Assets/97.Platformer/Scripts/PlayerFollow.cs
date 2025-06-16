using System;
using UnityEngine;

namespace Platformer
{
    public class PlayerFollow : MonoBehaviour
    {
        private Vector3 nextPos;
        
        private Player Player => GameManager.Instance.player;
        
        private void FixedUpdate()
        {
            FollowPlayer();
        }

        public void FollowPlayer()
        {
            nextPos = Player.transform.position;
            nextPos.z = transform.position.z;

            transform.position = Vector3.Lerp(transform.position, nextPos, 0.1f);
        }
    }
}