using UnityEngine;

namespace Assets.Scripts
{
    class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        
        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                _rigidbody2D.AddForce(Vector2.left * Config.PLAYER_MOVEMENT_SPEED);            

            if (Input.GetKey(KeyCode.RightArrow))
                _rigidbody2D.AddForce(Vector2.right * Config.PLAYER_MOVEMENT_SPEED);
        }
    }
}
