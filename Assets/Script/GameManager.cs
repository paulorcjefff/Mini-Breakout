using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniBreakout
{

    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private Ball balls;

        [SerializeField]
        private TextMeshProUGUI scoreText, livesText;

        [SerializeField]
        private Rigidbody2D ball;

        [SerializeField]
        private Transform paddle;

        [SerializeField]
        private int totalNumberBlock;

        [SerializeField]
        private int killBlocScore;

        [SerializeField]
        private int iniLivesPoint;

        [SerializeField]
        private AudioClip winaudioClip;

        private int livesPoints, playerScore;
        private Vector2 iniBallPosition;
        private bool velocidadeAumentada = false;

        void Start()
        {
            ball.transform.position = iniBallPosition;
            ball.gameObject.SetActive(false);
            livesPoints = iniLivesPoint;
            playerScore = killBlocScore;

            Invoke("ResetGame", 3);

        }

        private void ResetGame()
        {
            ball.gameObject.SetActive(true);

            ball.transform.position = iniBallPosition;
            paddle.transform.position = new Vector2(paddle.transform.position.x, 0);
            paddle.transform.position = new Vector2(paddle.transform.position.y, -4.5f);
            playerScore = 0;

            ShowScoreAndLives();
        }

        public void ResetBall()
        {
            ball.transform.position = new Vector2(0, -2);
            ball.gameObject.SetActive(true);

        }


        private void ReloadScene()
        {
            SceneManager.LoadScene(0);
        }



        private void ShowScoreAndLives()
        {
            scoreText.text = playerScore.ToString();
            livesText.text = livesPoints.ToString();
        }

        public void AddPoint()
        {
            playerScore += killBlocScore;
            ShowScoreAndLives();

            if (playerScore >= totalNumberBlock * killBlocScore)
            {
                AudioSource.PlayClipAtPoint(winaudioClip, transform.position);
                ball.gameObject.SetActive(false);
                Invoke("ReloadScene", 3);
            }
        }


        public void Update()
        {
            if (playerScore >= (totalNumberBlock * killBlocScore) * 0.5f && !velocidadeAumentada)
            {
                balls.IncreaseBallSpeed();
                velocidadeAumentada = true;
            }
        }

        public void RemoveLife()
        {
            livesPoints--;
            ShowScoreAndLives();
            ball.gameObject.SetActive(false);

            if (livesPoints <= 0)
            {
                Invoke("ReloadScene", 2);
            }
            else
            {
                Invoke("ResetBall", 1);
            }

        }
    }
}