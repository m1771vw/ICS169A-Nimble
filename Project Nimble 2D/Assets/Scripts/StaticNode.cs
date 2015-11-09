using UnityEngine;
using System.Collections;

public class StaticNode : MonoBehaviour {

    public int scoreValue;
    private ScoreController scoreController;
    public float lifeTime;
    public GameObject explosion;
    public AudioClip[] clips;
    public AudioClip randomSound;
    public AudioSource cutSource;
    public AudioClip cuttingSound;


    // Use this for initialization
    void Start () {

        cutSource = Camera.main.transform.Find("Cut Source").GetComponent<AudioSource>();
        GameObject gameControllerObject = GameObject.Find("ScoreControllers");
        if (gameControllerObject != null)
        {
            scoreController = gameControllerObject.GetComponent<ScoreController>();
        }
        if (scoreController == null)
        {
            Debug.Log("Cannot find 'ScoreController' script");
        }
        int random = Random.Range(0, clips.Length);
        GetComponent<AudioSource>().PlayOneShot(clips[random]);
    }

    void Awake() { Destroy(gameObject, lifeTime); }

    // Update is called once per frame
    void Update () {
	
	}


    void OnSpriteSliced(SpriteSlicer2DSliceInfo sliceInfo)
    {
        if (sliceInfo.SlicedObject)
        {
            cutSource.Play();
            Vector2 savedLocation = gameObject.transform.position;
            scoreController.AddScore(scoreValue);
            GameObject particle = Instantiate(explosion, savedLocation, Quaternion.identity) as GameObject;
            
        }
    }

}
