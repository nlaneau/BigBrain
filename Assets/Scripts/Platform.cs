using UnityEngine;

namespace Assets.Scripts
{
    class Platform : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(collision.gameObject);
        }
    }
}
