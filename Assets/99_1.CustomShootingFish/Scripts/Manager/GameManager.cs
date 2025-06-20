using System;
using Custom;
using UnityEngine;

namespace _99_1.CustomShootingFish
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public Player player;
        
        
        [Space(10),Header("Game Parameters")]
        [SerializeField] private GameParameters gameParameters = new GameParameters();
        

        public static GameParameters DefaultGameParam => Instance.gameParameters;
        
        private void Start()
        {
            player?.gameObject.SetActive(true);
        }


        private void EndGame()
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
    }
}