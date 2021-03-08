using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    class GameTimer : MonoBehaviour
    {
        public int _startTime = 30;
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

        private void Update()
        {
            int currentTime = 0;
            if (Countdown)
            {
                Timer += Time.deltaTime;

                currentTime = _startTime - (int)Timer % 60;

                TimerText.text = currentTime.ToString();
            }

            if (currentTime <= 0)
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
            return weight * 1.1235;
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
