using UnityEngine;
using System.Collections;

public class StaticNode : MonoBehaviour {

    private GUIText scoreReference;
    public float lifeTime;
    public GameObject explosion;
    public GameObject scorePopup;
    public AudioClip[] clips;
    private AudioClip randomSound;
    private AudioSource cutSource;
    private AudioClip cuttingSound;

    // Use this for initialization
    void Start () {

        cutSource = Camera.main.transform.Find("Cut Source").GetComponent<AudioSource>();
        scoreReference = GameObject.Find("Score").GetComponent<GUIText>();
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
            scoreReference.text = (int.Parse(scoreReference.text) + 1).ToString();
            GameObject particle = Instantiate(explosion, savedLocation, Quaternion.identity) as GameObject;
            GameObject popup = Instantiate(scorePopup, savedLocation, Quaternion.identity) as GameObject;

        }
    }

}
