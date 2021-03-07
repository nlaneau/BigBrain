using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class Head : MonoBehaviour
    {
        public AudioSource _small_head;
        public AudioSource _big_head;
        public int _currentWeight = 0;
        public int _maxWeight = 100;

        public WeightBar _weightBar;

        private void Start()
        {
            _currentWeight = 0;
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
                return;

            if (collision.gameObject.CompareTag("Environment"))
                return;

            if (collision.gameObject.CompareTag("SmarterObject"))
            {
                GainWeight(2);
                _big_head.Play();
                transform.localScale += new Vector3(Config.HEAD_GROWTH_SCALE, Config.HEAD_GROWTH_SCALE);                
            }
            else
            {
                var newScale = transform.localScale - new Vector3(Config.HEAD_GROWTH_SCALE, Config.HEAD_GROWTH_SCALE);
                _small_head.Play();
                LoseWeight(2);

                if (newScale.x > 0 && newScale.y > 0)
                    transform.localScale = newScale;
            }

            Destroy(collision.gameObject);
        }

        public void GainWeight(int weightIncrease)
        {
            _currentWeight = Math.Min(100, _currentWeight + weightIncrease);

            _weightBar.SetWeight(_currentWeight);
        }

        public void LoseWeight(int weightDecrease)
        {
            _currentWeight = Math.Max(0, _currentWeight - weightDecrease);

            _weightBar.SetWeight(_currentWeight);
        }
    }
}