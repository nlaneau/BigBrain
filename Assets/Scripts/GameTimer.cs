using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    class GameTimer : MonoBehaviour
    {
        public int _startTime = 30;
        private Text Text;

        private void Start()
        {
            Text = GetComponent<Text>();
        }

        private float Timer = 0f;

        private void Update()
        {
            Timer += Time.deltaTime;

            var currentTime = _startTime - (int)Timer % 60;

            Text.text = currentTime.ToString();

            if (currentTime <= 0)
            {
                // Do gameover check
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
