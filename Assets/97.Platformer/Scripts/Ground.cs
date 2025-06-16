using System;
using System.Linq;
using TreeEditor;
using UnityEngine;

namespace Platformer
{
    public class Ground : MonoBehaviour
    {
        [SerializeField] private Collider2D collisionCol;
        
        private bool isGround = false;
        public int index;
        private void Awake()
        {
            if (collisionCol == false)
                collisionCol = GetComponentsInChildren<Collider2D>().FirstOrDefault(col => col.isTrigger == false);
        }

        private void Update()
        {
            CheckGround();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Player")) return;
            
            collisionCol.gameObject.layer = LayerMask.NameToLayer("None");
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            Debug.Log("Exit");
            if (other.gameObject.layer != LayerMask.NameToLayer("Player")) return;
            
            collisionCol.gameObject.layer = LayerMask.NameToLayer("Ground");
        }

        private void CheckGround()
        {
            if (isGround) return;
            Vector2 center = collisionCol.bounds.center;
            Vector2 size = collisionCol.bounds.size;
            int mask = LayerMask.GetMask("Player");
            
            if (Physics2D.BoxCast(center, size, 0, Vector2.up, 0.1f, mask) == false) return;

            isGround = true;
            GameManager.Instance.Score++;
        }
    }
}