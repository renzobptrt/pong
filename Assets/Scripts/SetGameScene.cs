using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetGameScene : MonoBehaviour
{
    public BallController ball;
    public PlayerController player;
    public EnemyController enemy;

    public static Vector2 bottonLeft;
    public static Vector2 topRight;

    void Start()
    {
        //Convert screen's pixel coordinate to into game's coordinate
        bottonLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        //Convert screen's pixel coordinate to into game's coordinate
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        //Create ball
        Instantiate(ball);

        //Create two paddles
        Instantiate(player);
        Instantiate(enemy);

        //Start position
        player.Init();
        enemy.Init();
        ball.Init();
    }

}