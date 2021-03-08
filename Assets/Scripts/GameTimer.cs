using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    class GameTimer : MonoBehaviour
    {
        public Head _head;

        private Text TimerText;
        private Text GameOverText;
        private GameObject GameOverPanel;
        private ItemSpawner ItemSpawner;

        private void Start()
        {
            _head = (Head)FindObjectOfType(typeof(Head));
            TimerText = GetComponent<Text>();
            GameOverText = GameObject.Find("GameOverText").GetComponent<Text>();
            GameOverPanel = GameObject.Find("GameOverPanel");
            GameOverPanel.SetActive(false);
            ItemSpawner = (ItemSpawner)FindObjectOfType(typeof(ItemSpawner));
        }

        private float Timer = 0f;
        private bool Countdown = true;
        private int CurrentTime = 0;

        private void Update()
        {
            if (Countdown)
            {
                Timer += Time.deltaTime;

                CurrentTime = Config.ROUND_DURATION - (int)Math.Round(Timer % 60, 0);

                TimerText.text = CurrentTime.ToString();
            }

            if (CurrentTime <= 0)
            {
                GameOver();
                Countdown = false;
            }
        }

        private void GameOver()
        {
            ItemSpawner.DoSpawning = false;

            var weight = _head.GetCurrentWeight();
            var mass = CurrentWeightToMass(weight);
            var iq = MassToIQ(mass);

            GameOverPanel.SetActive(true);

            GameOverText.text = $"Your brain mass is {mass}kg.\nThat's an IQ of {iq}!";
        }

        private double CurrentWeightToMass(int weight)
        {
            return weight * 1.1235 + 1;
        }

        private int MassToIQ(double mass)
        {
            return (int)(mass * 2);
        }

        public void RetryButtonClicked()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
