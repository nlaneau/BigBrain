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
        public WeightBar _weightBar;

        private int CurrentWeight = 0;
        private int MaxWeight = 100;        

        private void Start()
        {

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
            CurrentWeight = Math.Min(MaxWeight, CurrentWeight + weightIncrease);

            _weightBar.SetWeight(CurrentWeight);
        }

        public void LoseWeight(int weightDecrease)
        {
            CurrentWeight = Math.Max(0, CurrentWeight - weightDecrease);

            _weightBar.SetWeight(CurrentWeight);
        }

        public int GetCurrentWeight()
            => CurrentWeight;
    }
}