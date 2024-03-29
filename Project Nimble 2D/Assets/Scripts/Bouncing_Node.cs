﻿using UnityEngine;
using System.Collections;

public class Bouncing_Node : MonoBehaviour
{
    public int scoreValue;
    private ScoreController scoreController;
    public float speed = 30;
    public float randNum = 0;
    public float lifeTime;
    public GameObject explosion;
    public AudioClip[] clips;
    public AudioClip randomSound;
    public AudioSource cutSource;

    void Start()
    {
        // Initial Velocity
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
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        int random = Random.Range(0, clips.Length);
        GetComponent<AudioSource>().PlayOneShot(clips[random]);
    }

    void Awake()
    {
        Destroy(gameObject, lifeTime);
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
