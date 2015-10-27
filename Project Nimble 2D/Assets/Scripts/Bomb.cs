using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
	private GUIText scoreReference;
    public float lifeTime;
    public GameObject explosion;
    public AudioClip[] clips;
    private AudioClip randomSound;
    private AudioSource ExplosionSource;

    void Start()
    {
        ExplosionSource = Camera.main.transform.Find("Bomb Source").GetComponent<AudioSource>();
        scoreReference = GameObject.Find("Score").GetComponent<GUIText>();
        int random = Random.Range(0, clips.Length);
        GetComponent<AudioSource>().PlayOneShot(clips[random]);
    }

    void Awake() { Destroy(gameObject, lifeTime); }

    void Update()
    {
        /* Remove fruit if out of view */
        if (gameObject.transform.position.y < -36)
        {
            Destroy(gameObject);
        }
    }

    void OnSpriteSliced(SpriteSlicer2DSliceInfo sliceInfo)
    {
        if (sliceInfo.SlicedObject)
        {
            ExplosionSource.Play();
            Vector2 savedLocation = gameObject.transform.position;
            scoreReference.text = (int.Parse(scoreReference.text) - 5).ToString();
            GameObject particle = Instantiate(explosion, savedLocation, Quaternion.identity) as GameObject;

        }
    }
}