using System;
using UnityEngine;

namespace SpaceShooter
{
    public enum BuffType
    {
        None = 0,
        MoveSpeed,
        AttackInterval,
        Damage,
        Heal,
    }
    public class Item : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer render;
        [SerializeField] private Collider2D col;
        [SerializeField] private BuffType type;
        public float increaseValue;

        private void Awake()
        {
            if (render == false) transform.Find("Renderer").GetComponent<SpriteRenderer>();
            if (col == false) GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player") == false) return;
            if (other.TryGetComponent(out IBuff buff) == false) return;
            
            buff.Buff(type, increaseValue);
            //todo : 아이템 획득 이펙트
        }
    }
}