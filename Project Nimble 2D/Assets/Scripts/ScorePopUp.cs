using UnityEngine;
using System.Collections;

public class ScorePopUp : MonoBehaviour {

    public float risingSpeed = 30;
    public float lifeTime;
    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * risingSpeed;
    }

    void Awake() {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
