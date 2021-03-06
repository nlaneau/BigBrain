using UnityEngine;

namespace Assets.Scripts
{
    class PlayerMovement : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                transform.Translate(-Config.PLAYER_MOVEMENT_SPEED, 0, 0);
            if (Input.GetKey(KeyCode.RightArrow))
                transform.Translate(Config.PLAYER_MOVEMENT_SPEED, 0, 0);
        }
    }
}
