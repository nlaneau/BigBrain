using System;
using UnityEngine;

namespace Assets.Scripts
{
    class Head : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Environment"))
                return;

            if (collision.gameObject.CompareTag("SmarterObject"))
                transform.localScale += new Vector3(Config.HEAD_GROWTH_SCALE, Config.HEAD_GROWTH_SCALE);
            else
            {
                var newScale = transform.localScale - new Vector3(Config.HEAD_GROWTH_SCALE, Config.HEAD_GROWTH_SCALE);

                if (newScale.x > 0 && newScale.y > 0)
                    transform.localScale = newScale;
            }

            Destroy(collision.gameObject);
        }
    }
}