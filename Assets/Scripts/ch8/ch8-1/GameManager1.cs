using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]
public class GameManager1 : MonoBehaviour
{
    [SerializeField] private Ball1 ball;
    [SerializeField] private GameObject BallPrfab;
    [SerializeField] private Paddle1 playerPaddle;
    [SerializeField] private Paddle1 computerPaddle;
    [SerializeField] private Text playerScoreText;
    [SerializeField] private Text computerScoreText;

    private int playerScore;
    private int computerScore;
    private int additionalBalls=0;

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            NewGame();
        }
    }

    public void NewGame()
    {
        SetPlayerScore(0);
        SetComputerScore(0);
        NewRound();
    }

    public void NewRound()
    {
        playerPaddle.ResetPosition();
        computerPaddle.ResetPosition();
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach(GameObject a in balls) Destroy(a);
        ball.ResetPosition();

        CancelInvoke();
        Invoke(nameof(StartRound), 1f);
    }

    private void StartRound()
    {
        ball.AddStartingForce();
        for (int i = 0; i < additionalBalls; i++) 
        {
            GameObject go = Instantiate(BallPrfab);
            int px = Random.Range(-4, 4);
            int py=Random.Range(-1, 1);
            go.transform.position=new Vector3(px, py, 0);
            Ball1 ballscript=go.GetComponent<Ball1>();
            ballscript.AddStartingForce();
        }
        additionalBalls++;
    }

    public void OnPlayerScored()
    {
        SetPlayerScore(playerScore + 1);
        NewRound();
    }

    public void OnComputerScored()
    {
        SetComputerScore(computerScore + 1);
        NewRound();
    }

    private void SetPlayerScore(int score)
    {
        playerScore = score;
        playerScoreText.text = score.ToString();
    }

    private void SetComputerScore(int score)
    {
        computerScore = score;
        computerScoreText.text = score.ToString();
    }


}
