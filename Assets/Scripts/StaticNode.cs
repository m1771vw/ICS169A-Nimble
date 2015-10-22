using UnityEngine;
using System.Collections;

public class StaticNode : MonoBehaviour {

    private GUIText scoreReference;
    public float lifeTime;

    // Use this for initialization
    void Start () {
        scoreReference = GameObject.Find("Score").GetComponent<GUIText>();
    }

    void Awake() { Destroy(gameObject, lifeTime); }

    // Update is called once per frame
    void Update () {
	
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Line")
        {
            Destroy(gameObject);

            /* Update Score */

            scoreReference.text = (int.Parse(scoreReference.text) + 1).ToString();
        }
    }
}
