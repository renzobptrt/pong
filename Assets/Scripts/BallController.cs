using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    //In features
    Vector3 startPosition = Vector3.zero;
    private float radius;
    public float velocity;

    //Extern features
    private Rigidbody2D rb2d;
    private CircleCollider2D cc2d;
    private GameObject player, enemy;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        cc2d = GetComponent<CircleCollider2D>();
        player = GameObject.Find("Player");
        enemy = GameObject.Find("Enemy");
    }

    public void Init()
    {
        //Update the position
        transform.position = startPosition;
    }


    void Start()
    {
        radius = cc2d.radius;
        StartCoroutine(Move());
    }


    void FixedUpdate()
    {
        if (Mathf.Abs(this.transform.position.x) >= 9f)
        {
            this.transform.position = startPosition;
            StartCoroutine(Move());
        }

    }

    IEnumerator Move()
    {
        int directionX = Random.Range(-1, 2);
        int directionY = Random.Range(-1, 2);
        if (directionX == 0)
            directionX = 1;
        rb2d.velocity = Vector2.zero;
        yield return new WaitForSeconds(2);
        rb2d.velocity = new Vector2(velocity * directionX, velocity * directionY);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (other.gameObject.transform.position.y == this.transform.position.y)
            {
                rb2d.velocity = new Vector2(velocity, 0f);
            }

            else
            {
                if (rb2d.velocity.y <= 0)
                    rb2d.velocity = new Vector2(velocity, -velocity);
                else if (rb2d.velocity.y > 0)
                    rb2d.velocity = new Vector2(velocity, velocity);
            }
        }
        else if (other.gameObject.tag.Equals("Enemy"))
        {
            if (other.gameObject.transform.position.y == this.transform.position.y)
                rb2d.velocity = new Vector2(-velocity, 0f);
            else
            {
                if (rb2d.velocity.y < 0)
                    rb2d.velocity = new Vector2(-velocity, -velocity);
                else if (rb2d.velocity.y >= 0)
                    rb2d.velocity = new Vector2(-velocity, velocity);
            }
        }
    }
}


