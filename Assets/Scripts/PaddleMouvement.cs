using UnityEngine;

public class PaddleMouvement : MonoBehaviour
{
    public float speed = 10;
    public string axis = "Vertical";

    void FixedUpdate(){
        float v = Input.GetAxisRaw(axis);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;
    }
}
