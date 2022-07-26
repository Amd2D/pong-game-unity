using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScore : MonoBehaviour
{
    public AudioSource scoreAudio;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "ball")
        {
            scoreAudio.Play();
            string wallName = transform.name;
            GameManager.instance.Score(wallName);
            col.gameObject.SendMessage("StartMatch", null, SendMessageOptions.RequireReceiver);
        }
    }
}
