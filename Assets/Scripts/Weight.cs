using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Weight : MonoBehaviour
    {
        public int _currentWeight = 0;
        public int _maxWeight = 100;

        public WeightBar _weightBar;

        private void Start()
        {
            _currentWeight = _maxWeight;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GainWeight(5);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow)
                || Input.GetKeyDown(KeyCode.RightArrow))
            {
                LoseWeight(25);
            }
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
