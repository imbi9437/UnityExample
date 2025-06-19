using Custom;
using UnityEngine;

namespace _99.ShootingFishTest
{
    public partial class GameManager : MonoSingleton<GameManager>
    {
        public Player player;
        public Spawner spawner;

        public float effectSpeed;
        public Gradient hitEffectGradient;

        public void PauseGame(bool isPause)
        {
            Time.timeScale = isPause ? 0 : 1;
        }
    }
}