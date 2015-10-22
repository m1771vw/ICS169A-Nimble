using UnityEngine;
using System.Collections;

public class Bouncing_Node : MonoBehaviour
{
    public float speed = 30;
    public float randNum = 0;
    public float lifeTime =;

    void Start()
    {
        // Initial Velocity
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    void Awake()
    {
        Destroy(gameObject, lifeTime);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        randNum = Random.Range(-5, 5); 
        // Hit the right Wall?
        if (col.gameObject.tag == "Right Wall")
        {
            Vector2 dir = new Vector2(-1, randNum);

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        if (col.gameObject.tag == "Left Wall")
        {
            Vector2 dir = new Vector2(1, randNum);

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        if (col.gameObject.tag == "Top Wall")
        {
            Vector2 dir = new Vector2(randNum, -1);

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        if (col.gameObject.tag == "Bottom Wall")
        {
            Vector2 dir = new Vector2(randNum, 1);

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }
}
