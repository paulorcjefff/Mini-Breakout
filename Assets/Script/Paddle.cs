using UnityEngine;

namespace MiniBreakout
{


    public class Paddle : MonoBehaviour
    {
        public float speed = 2;
        public float horizontalLimitMax = 4.2f;
        public float horizontalLimitMin = -4.2f;

        void Update()
        {
            float move = Input.GetAxis("Horizontal") * speed;

            float nexPlayerPosition = transform.position.x + (move * Time.deltaTime);

            float clampedPositionX = Mathf.Clamp(nexPlayerPosition, horizontalLimitMin, horizontalLimitMax);

            transform.position = new Vector3(clampedPositionX, transform.position.y, transform.position.z);
        }
    }
}
