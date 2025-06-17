using System;
using System.Collections;
using System.Linq;
using _00.Custom;
using UnityEngine;

namespace Platformer
{
    public class Ground : MonoBehaviour
    {
        [SerializeField] private Collider2D collisionCol;

        private Coroutine removePosCo;
        
        private bool isGround;
        
        
        private void Awake()
        {
            if (collisionCol == false)
                collisionCol = GetComponentsInChildren<Collider2D>().FirstOrDefault(col => col.isTrigger == false);
        }

        private void OnEnable()
        {
            removePosCo = StartCoroutine(RemovePosCo());
        }
        
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Player")) return;
            
            collisionCol.gameObject.layer = LayerMask.NameToLayer("None");
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Player")) return;
            
            collisionCol.gameObject.layer = LayerMask.NameToLayer("Ground");
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (isGround) return;
            
            isGround = true;
            GameManager.Instance.Score++;
        }

        private void OnDisable()
        {
            StopCoroutine(removePosCo);
            removePosCo = null;
            isGround = false;
        }
        

        private IEnumerator RemovePosCo()
        {
            yield return YieldCache.WaitUntil(CheckGround);
            yield return YieldCache.WaitForSeconds(GameManager.Instance.groundRemoveDelay);
            
            GameManager.Instance.RemoveGround(this);
        }
        
        private bool CheckGround() => isGround;
    }
}