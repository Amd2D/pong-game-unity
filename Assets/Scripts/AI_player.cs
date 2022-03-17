using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_player : PaddleMouvement
{
    public Rigidbody2D ball;
    private void FixedUpdate()
    {
        if (ball.velocity.x > 0)
        {
            if (ball.position.y > this.transform.position.y)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * this.speed);
            }
            else if (ball.position.y < this.transform.position.y)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.down * this.speed);
            }
        }
        else
        {
            if (this.transform.position.y > 0)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.down * this.speed);
            }
            else if (this.transform.position.y < 0)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * this.speed);
            }
        }
    }
}
