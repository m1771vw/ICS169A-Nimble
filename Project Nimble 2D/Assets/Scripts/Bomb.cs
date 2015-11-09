using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    [SerializeField]
    private GameObject splashReference;
    private Vector3 randomPos = new Vector3(Random.Range(-1, 1), Random.Range(0.3f, 0.7f), Random.Range(-6.5f, -7.5f));
    public int scoreValue;
    private ScoreController scoreController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.Find("ScoreControllers");
        if (gameControllerObject != null)
        {
            scoreController = gameControllerObject.GetComponent<ScoreController>();
        }
        if (scoreController == null)
        {
            Debug.Log("Cannot find 'ScoreController' script");
        }
    }
    
    void Update()
    {
        /* Remove fruit if out of view */
        if (gameObject.transform.position.y < -36)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Line")
        {
			Camera.main.GetComponent<AudioSource>().Play();
			Destroy(gameObject);

            Instantiate(splashReference, randomPos, transform.rotation);

            /* Update Score */

            scoreController.AddScore(scoreValue);
        }
    }
}