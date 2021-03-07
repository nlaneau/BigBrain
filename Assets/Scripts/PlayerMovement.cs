using UnityEngine;

namespace Assets.Scripts
{
    class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private GameObject _body;
        private GameObject _head;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _body = GameObject.Find("Body");
            _head = GameObject.Find("Head");
        }

        private void RotateBoy()
        {
            _body.transform.Rotate(0, 180, 0, Space.Self);
            _head.transform.Rotate(0, 180, 0, Space.Self);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && _body.transform.rotation.y != 0)
            {
                RotateBoy();
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) && _body.transform.rotation.y != 180)
            {
                RotateBoy();
            }

            if (Input.GetKey(KeyCode.LeftArrow))
                _rigidbody2D.AddForce(Vector2.left * Config.PLAYER_MOVEMENT_SPEED);

            if (Input.GetKey(KeyCode.RightArrow))
                _rigidbody2D.AddForce(Vector2.right * Config.PLAYER_MOVEMENT_SPEED);
        }
    }
}
