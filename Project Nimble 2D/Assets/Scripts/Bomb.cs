using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    public GameObject multiplayerData;
    private SavedMultiplayerData data;
    private GUIText scoreReference;
    public float lifeTime;
    public GameObject explosion;
    public AudioClip[] clips;
    public GameObject scorePopup;
    private AudioClip randomSound;
    private AudioSource ExplosionSource;

    void Start()
    {
        ExplosionSource = Camera.main.transform.Find("Bomb Source").GetComponent<AudioSource>();
        scoreReference = GameObject.Find("Score").GetComponent<GUIText>();
        int random = Random.Range(0, clips.Length);
        GetComponent<AudioSource>().PlayOneShot(clips[random]);

        multiplayerData = GameObject.Find("MultiplayerData");
        data = multiplayerData.GetComponent<SavedMultiplayerData>();

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
            Debug.Log("sliced");

            ExplosionSource.Play();
            Vector2 savedLocation = gameObject.transform.position;
            scoreReference.text = (int.Parse(scoreReference.text) - 5).ToString();
            GameObject particle = Instantiate(explosion, savedLocation, Quaternion.identity) as GameObject;
            GameObject popup = Instantiate(scorePopup, savedLocation, Quaternion.identity) as GameObject;

            if (data.inMultiplayer == true)
            {
                data.setFail(data.currentPlayerInt);
                if(data.firstPlayer == data.lastPlayer)
                {
                    //all failed
                    Application.LoadLevel("AllFailScreen");
                }
                else if(data.currentPlayerInt == data.lastPlayer)
                {
                    data.roundCounter++;
                    data.currentPlayerInt = data.firstPlayer;
                    Application.LoadLevel("Round Counter");
                    return;
                }

                for (int i = data.currentPlayerInt; i < data.numberOfPlayers; i++)
                {
                   
                    if (data.getPassOrFail(data.currentPlayerInt + 1) == true)
                    {
                        if (data.currentPlayerInt == data.firstPlayer)
                        {
                            data.firstPlayer = i + 1;
                        }
           
                        data.currentPlayerInt = i + 1;
                        Application.LoadLevel("Fail");
                        break;
                    }    
                }
            }
        }
    }
}