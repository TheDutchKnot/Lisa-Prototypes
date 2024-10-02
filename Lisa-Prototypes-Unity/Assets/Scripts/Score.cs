using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Tdk.Systems.ObjectPooling
{
    public class Score : MonoBehaviour
    {
        public static Score instance;
        public TMP_Text scoreText;
        public TMP_Text highscoreText;


        int score = 0;
        int highscore = 0;

        private void Awake()
        {
            instance = this;
        }

        void Start()
        {
            highscore = PlayerPrefs.GetInt("highscore", 0);
            scoreText.text = score.ToString();
            highscoreText.text = "HIGHSCORE: " + highscore.ToString();
        }

        public void AddPoint(int pointValue)
        {
            score += pointValue; 
            scoreText.text = score.ToString();

            if (highscore < score)
                PlayerPrefs.SetInt("highscore", score);
        }
    }
}
