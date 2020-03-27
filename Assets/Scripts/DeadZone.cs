using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //To access the various functions

public class DeadZone : MonoBehaviour
{
    public TextMeshProUGUI scorePlayerText;
    public TextMeshProUGUI scoreEnemyText;

    private int scorePlayer;
    private int scoreEnemy;

    private GameObject gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager");
    }

    void Update()
    {
        CheckScore();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.tag.Equals("Left"))
        {
            scoreEnemy++;
            UpdateScoreLabel(scoreEnemyText, scoreEnemy);
        }
        else if (gameObject.tag.Equals("Right"))
        {
            scorePlayer++;
            UpdateScoreLabel(scorePlayerText, scorePlayer);
        }
    }

    void UpdateScoreLabel(TextMeshProUGUI label, int score)
    {
        label.text = score.ToString();
    }

    void CheckScore()
    {
        if (scorePlayer >= 3)
        {
            gameManager.GetComponent<GameManager>().ChangeScene("WinScene");
            Debug.Log("Go To Win Scene");
        }
        else if (scoreEnemy >= 3)
        {
            gameManager.GetComponent<GameManager>().ChangeScene("GameOverScene");
        }
    }
}
