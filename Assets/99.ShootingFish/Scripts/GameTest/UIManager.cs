using System;
using Custom;
using UnityEngine;
using UnityEngine.UI;

namespace _99.ShootingFishTest
{
    public class UIManager : MonoSingleton<UIManager>
    {
        public Toggle pauseToggle;
        public Image hpGauge;
        public Image expGauge;

        private void Start()
        {
            InputManager.Instance.OnEscape += ChangeToggle;
        }

        private void ChangeToggle()
        {
            pauseToggle.isOn = !pauseToggle.isOn;
        }

        private void OnDestroy()
        {
            if (InputManager.Instance == null) return;
            InputManager.Instance.OnEscape -= ChangeToggle;
        }
    }
}
