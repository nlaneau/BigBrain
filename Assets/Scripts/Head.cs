using UnityEngine;

namespace Assets.Scripts
{
    class Head : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.CompareTag("Environment"))
            {
                transform.localScale += new Vector3(Config.HEAD_GROWTH_SCALE, Config.HEAD_GROWTH_SCALE);
                Destroy(collision.gameObject);
            }
        }
    }
}
