using UnityEngine;
using System.Collections;

public class Bouncing_Node : MonoBehaviour
{
    GUIText scoreReference;
    public float speed = 30;
    public float randNum = 0;
    public float lifeTime;

    void Start()
    {
        // Initial Velocity
        scoreReference = GameObject.Find("Score").GetComponent<GUIText>();
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    void Awake()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnSpriteSliced(SpriteSlicer2DSliceInfo sliceInfo)
    {
        if (sliceInfo.SlicedObject)
        {
            scoreReference.text = (int.Parse(scoreReference.text) + 1).ToString();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        randNum = Random.Range(-5, 5); 
        // Hit the right Wall?
        if (col.gameObject.name == "Right Wall")
        {
            Vector2 dir = new Vector2(-1, randNum);

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        if (col.gameObject.name == "Left Wall")
        {
            Vector2 dir = new Vector2(1, randNum);

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        if (col.gameObject.name == "Top Wall")
        {
            Vector2 dir = new Vector2(randNum, -1);

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
        if (col.gameObject.name == "Bottom Wall")
        {
            Vector2 dir = new Vector2(randNum, 1);

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }
}
