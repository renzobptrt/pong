using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject ball;
    public float speed;
    private float speedBeetwen;
    void Start()
    {

    }

    public void Init()
    {
        Vector2 pos = Vector2.zero;
        pos = new Vector2(SetGameScene.topRight.x - 1f, 0);
        //Update the position
        transform.position = pos;
    }

    private void Awake()
    {
        ball = GameObject.FindWithTag("Ball");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ball.transform.position.x > 0)
        {
            //speedBeetwen = Random.Range(speed - 0.08f, speed + 0.05f);
            if (this.transform.position.y < ball.transform.position.y)
            {
                this.transform.localPosition += new Vector3(0, speed * Time.deltaTime, 0);
            }
            else if (this.transform.position.y > ball.transform.position.y)
            {
                this.transform.localPosition += new Vector3(0, -speed * Time.deltaTime, 0);
            }
        }
    }
}
