using System;
using UnityEngine;

namespace Assets.Scripts
{
    class PlayerMovement : MonoBehaviour
    {
        public Camera _mainCam;

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
                MoveLeft();
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                MoveRight();
            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                ClickMove();
            }
        }

        private void MoveLeft()
        {
            Move(Vector2.left);
        }

        private void MoveRight()
        {
            Move(Vector2.right);
        }

        private void Move(Vector2 direction)
        {
            var newSpeed = Math.Max(Config.PLAYER_MOVEMENT_SPEED - (_head.transform.localScale.magnitude * Config.HEAD_SLOW_DOWN_MULTIPLIER), 1f);
            _rigidbody2D.AddForce(direction * newSpeed);
        }

        private void ClickMove()
        {
            var mousePos = _mainCam.ScreenToWorldPoint(Input.mousePosition);

            if (mousePos.x > this.transform.position.x)
            {
                MoveRight();
                return;
            }

            if (mousePos.x < this.transform.position.x)
            {
                MoveLeft();
                return;
            }
        }
    }
}
