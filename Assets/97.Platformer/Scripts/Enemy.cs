using System;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer
{
    public class Enemy : MonoBehaviour
    {
        private SpriteRenderer renderer;
        private Player target;
        private float moveSpeed;
        private float lifeTime;

        public Image effectImage;
        public Image hpGauge;
        
        public float lifeTimeMax = 10f;
        
        private void Awake()
        {
            renderer = GetComponentInChildren<SpriteRenderer>();
        }

        private void Update()
        {
            if (effectImage.fillAmount > 0f)
            {
                effectImage.fillAmount -= Time.deltaTime * 0.5f;
                return;
            }
            
            Vector3 dir = target.transform.position - transform.position;
            dir.z = 0;
            dir = dir.normalized;
            
            Vector3 nextPos = transform.position + dir * (moveSpeed * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, nextPos, 0.9f);

            if (Mathf.Approximately(dir.x, 0f) == false)
            {
                renderer.flipY = dir.x < 0f;
            }
            renderer.transform.right = dir;
            
            lifeTime += Time.deltaTime;
            hpGauge.fillAmount = 1 - lifeTime/lifeTimeMax;

            if (hpGauge.fillAmount <= 0f)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer != LayerMask.NameToLayer("Player")) return;
            Player player = other.gameObject.GetComponent<Player>();
            Vector2 dir = other.gameObject.transform.position - transform.position;
            GameManager.Instance.playerHitAction?.Invoke();
            Destroy(gameObject);
        }

        public void Init(Player target, float moveSpeed)
        {
            this.target = target;
            this.moveSpeed = moveSpeed;
        }
    }
}
