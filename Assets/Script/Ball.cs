using UnityEngine;

namespace MiniBreakout
{

    public class Ball : MonoBehaviour
    {
        [SerializeField]
        private GameManager gameManager;

        [SerializeField]
        private float iniBallSpeed = 5f;

        [SerializeField]
        private AudioClip paddleaudioClip;

        [SerializeField]
        private AudioClip wallaudioClip;

        [SerializeField]
        private AudioClip wallkillaudioClip;

        [SerializeField]
        private AudioClip blockaudioClip;

        [SerializeField]
        private string horizontalWallTag, verticalWallTag, paddleTag, blockTag, killVericalWassTag;

        private float ballSpeed;
        private Vector2 direction;

        private void Start()
        {
            direction = new Vector2(1, 1);
            ballSpeed = iniBallSpeed;

        }

        private void Update()
        {
            Move();
        }

        public void Move()
        {
            transform.Translate(direction * ballSpeed * Time.deltaTime);
        }

        public void IncreaseBallSpeed()
        {
            ballSpeed += 2f;
            direction = new Vector2(-direction.x, direction.y);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == horizontalWallTag)
            {
                AudioSource.PlayClipAtPoint(wallaudioClip, transform.position);
                direction = new Vector2(-direction.x, direction.y);
            }

            if (collision.gameObject.tag == verticalWallTag)
            {
                AudioSource.PlayClipAtPoint(wallaudioClip, transform.position);
                direction = new Vector2(direction.x, -direction.y);
            }

            if (collision.gameObject.tag == killVericalWassTag)
            {
                AudioSource.PlayClipAtPoint(wallkillaudioClip, transform.position);
                direction = new Vector2(1, 1);
                gameManager.RemoveLife();
            }

            if (collision.gameObject.tag == blockTag)
            {
                AudioSource.PlayClipAtPoint(blockaudioClip, transform.position);
                collision.gameObject.SetActive(false);
                direction = new Vector2(direction.x, -direction.y);
                gameManager.AddPoint();
            }

            if (collision.gameObject.tag == paddleTag)
            {
                AudioSource.PlayClipAtPoint(paddleaudioClip, transform.position);
                direction = new Vector2(direction.x, -direction.y);

            }
        }


    }
}
