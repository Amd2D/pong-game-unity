using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 10;
    private float ballDir;

    void Start()
    {

        ballDir = Random.Range(0, 2);
        Invoke("StartMatch", 1);
    }

    public void StartMatch()
    {
        transform.position = new Vector2(0, 0);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        if (ballDir == 1)
        {
            ballDir = 0;
            GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
        }
        else
        {
            ballDir = 1;
            GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        }
    }

    void RestartGame()
    {
        transform.position = new Vector2(0, 0);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        Invoke("StartMatch", 1);
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "player_1")
        {
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);
            Vector2 dir = new Vector2(1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        if (col.gameObject.name == "player_2")
        {
            float y = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);
            Vector2 dir = new Vector2(-1, y).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }
}
