using UnityEngine;

namespace Assets.Scripts
{
    class Platform : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.CompareTag("Player"))
                Destroy(collision.gameObject);
        }
    }
}
