using System;
using UnityEngine;

namespace Assets.Scripts
{
    class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private GameObject _body;
        private GameObject _head;
        private bool _isFacingLeft;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _body = GameObject.Find("Body");
            _head = GameObject.Find("Head");
            _isFacingLeft = true;
        }

        private void RotateBoy()
        {
            _body.transform.Rotate(0, 180, 0, Space.Self);
            _head.transform.Rotate(0, 180, 0, Space.Self);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && !_isFacingLeft)
            {
                RotateBoy();
                _isFacingLeft = true;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) && _isFacingLeft)
            {
                RotateBoy();
                _isFacingLeft = false;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                var newSpeed = Math.Max(Config.PLAYER_MOVEMENT_SPEED - (_head.transform.localScale.magnitude * Config.HEAD_SLOW_DOWN_MULTIPLIER), 1f);
                _rigidbody2D.AddForce(Vector2.left * newSpeed);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                var newSpeed = Math.Max(Config.PLAYER_MOVEMENT_SPEED - (_head.transform.localScale.magnitude * Config.HEAD_SLOW_DOWN_MULTIPLIER), 1f);
                _rigidbody2D.AddForce(Vector2.right * newSpeed);
            }
        }
    }
}
