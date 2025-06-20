using System;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{
    public class ScoreText : MonoBehaviour
    {
        private Text text;

        private void Awake()
        {
            text = GetComponent<Text>();
        }

        private void Update()
        {
            text.text = Player.score.ToString();
        }
    }
}