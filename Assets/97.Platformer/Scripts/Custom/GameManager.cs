using System;
using System.Collections;
using System.Collections.Generic;
using Custom;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Platformer
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public Player player;
        public Ground originGround;
        public Enemy enemyOrigin;
        public Transform minHeight;


        [Space(10), Header("UI")] 
        public Text text;
        public Toggle pauseToggle;
        public Image hitGauge;
        public Image pauseGauge;

        [Space(15), Header("InGame Setting Value")]
        public int maxEnemyCount = 30;

        public int maxHitCount = 10;
        public float generateDistance = 4f;
        public float groundRemoveDelay = 5f;
        public Vector2 enemySpeed;

        public Action playerHitAction;

        private Queue<Ground> groundQueue = new Queue<Ground>();
        private Coroutine pauseCo;

        private int score;
        private int hitCount;

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
            Score = 0;
            hitCount = 0;
            StartCoroutine(SpawnEnemy());
            pauseToggle.onValueChanged.AddListener(PauseGame);
            
            playerHitAction += HitCheck;
        }

        private void Update()
        {
            if (player.transform.position.y < minHeight.position.y)
            {
                EndGame();
            }
        }

        private void OnDestroy()
        {
            pauseToggle.onValueChanged.RemoveListener(PauseGame);
        }

        private void GenerateGround()
        {
            Ground ground = groundQueue.Count <= 0
                ? Instantiate(originGround, Vector3.zero, Quaternion.identity)
                : groundQueue.Dequeue();

            Vector2 randomPos = Random.insideUnitCircle * generateDistance;
            Vector3 pos = player.transform.position + new Vector3(randomPos.x, randomPos.y, 0);
            pos.y = Mathf.Max(minHeight.position.y, pos.y);
            ground.transform.position = pos;
            ground.gameObject.SetActive(true);
        }

        public void RemoveGround(Ground ground)
        {
            groundQueue.Enqueue(ground);
            ground.gameObject.SetActive(false);
            GenerateGround();
        }

        private IEnumerator SpawnEnemy()
        {
            while (true)
            {
                yield return YieldCache.WaitForSeconds(2f);

                Vector2 randomPos = Random.insideUnitCircle * generateDistance;
                Vector3 pos = player.transform.position + new Vector3(randomPos.x, randomPos.y, 0);

                Enemy enemy = Instantiate(enemyOrigin, pos, Quaternion.identity);
                enemy.Init(player, Random.Range(enemySpeed.x, enemySpeed.y));
            }
        }

        private void HitCheck()
        {
            hitCount++;
            hitGauge.fillAmount = hitCount / (float) maxHitCount;
            
            if (hitCount >= maxHitCount)
                EndGame();
        }

        private void PauseGame(bool isOn)
        {
            Time.timeScale = isOn ? 0 : 1;
        }

        private void EndGame()
        {
#if UNITY_EDITOR
            Debug.Log("<color=#FF0000>Game Over</color>");
            UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
        }
    }
}