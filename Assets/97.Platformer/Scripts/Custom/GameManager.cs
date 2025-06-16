using System;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer
{
    public class GameManager : MonoSingleton<GameManager>
    {
        private const int initGroundCount = 20;
        
        public Player player;
        public Ground originGround;

        [Space(10), Header("UI")] public Text text;
        
        [Space(15),Header("InGame Setting Value")]
        public float maxPossibleDistance = 20f;
        public float groundHeightDiff = 4f;
        
        [Range(-8f, 0f)] public float maxLeftPos;
        [Range(0f, 8f)] public float maxRightPos;

        private int groundIndex;
        private float bestHeight = float.MinValue;
        private int score;

        public int Score
        {
            get => score;
            set
            {
                score = value;
                text.text = $"Score : {score}";
            }
        }
        
        private void Start()
        {
            groundIndex = 1;
            InitGround();
            text.text = $"Score : {score}";
        }

        private void Update()
        {
            if (player.transform.position.y > bestHeight) bestHeight = player.transform.position.y;

            if (player.transform.position.y < bestHeight - maxPossibleDistance)
            {
                #if UNITY_EDITOR
                Debug.Log("<color=#FF0000>Game Over</color>");
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
            }
        }

        private void InitGround()
        {
            for (int i = 0; i < initGroundCount; i++)
            {
                float height = groundIndex * groundHeightDiff;
                float xPos = UnityEngine.Random.Range(maxLeftPos, maxRightPos);
                Vector2 pos = new Vector2(xPos, height);
                var obj = Instantiate(originGround, pos, Quaternion.identity);
                obj.gameObject.name += i;
                groundIndex++;
            }
        }

        public void GenerateGround(Ground ground)
        {
            float yPos = groundIndex * groundHeightDiff;
            float xPos = UnityEngine.Random.Range(maxLeftPos, maxRightPos);
            
            Vector3 pos = new Vector3(xPos, yPos, 0f);
            ground.transform.position = pos;
            groundIndex++;
            ground.index = groundIndex;
        }
    }
}