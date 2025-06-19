using System;
using UnityEngine;
using UnityEngine.UI;

namespace _08.UGUITest
{
    public class HpBar : MonoBehaviour
    {
        [SerializeField] private Image gauge;
        [SerializeField] private Text text;

        public float maxHp;
        public float currentHp;

        private void Start()
        {
            currentHp = maxHp;
        }

        public void HpChange(float hp)
        {
            currentHp = hp;
            gauge.fillAmount = currentHp / maxHp;
            text.text = $"{currentHp:n0} / {maxHp:n0}";
        }
    }
}
