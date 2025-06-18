using System;
using System.Collections;
using System.Linq;
using Custom;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer
{
    public class Ground : MonoBehaviour
    {
        [SerializeField] private Collider2D collisionCol;
        
        public Image gauge;
        public Transform arrow;
        public Canvas canvas;
        
        
        private Coroutine removePosCo;
        
        private bool isGround;
        private float liftTime;
        
        
        private void Awake()
        {
            if (collisionCol == false)
                collisionCol = GetComponentsInChildren<Collider2D>().FirstOrDefault(col => col.isTrigger == false);
        }

        private void OnEnable()
        {
            removePosCo = StartCoroutine(RemovePosCo());
            liftTime = 0f;
        }


        private void Update()
        {
            if (isGround)
            {
                liftTime += Time.deltaTime;
                gauge.fillAmount = 1 - liftTime / GameManager.Instance.groundRemoveDelay;
                Quaternion from = Quaternion.Euler(0,0,-90);
                Quaternion to = Quaternion.Euler(0,0,90);
                
                arrow.rotation = Quaternion.Slerp(from, to, liftTime / GameManager.Instance.groundRemoveDelay);
            }
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
            canvas.enabled = true;
            
        }

        private void OnDisable()
        {
            StopCoroutine(removePosCo);
            removePosCo = null;
            isGround = false;
            canvas.enabled = false;
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