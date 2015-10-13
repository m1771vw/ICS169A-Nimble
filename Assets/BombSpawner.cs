using UnityEngine;
using System.Collections;

public class BombSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject bombReference;
    private Vector3 throwForce = new Vector3(0, 18, 0);

    void Start()
    {
        InvokeRepeating("SpawnBomb", 0.5f, 6);
    }

    void SpawnBomb()
    {
        for (byte i = 0; i < 4; i++)
        {
            GameObject bomb = Instantiate(bombReference, new Vector3(Random.Range(10, 30), Random.Range(-25, -35), -32), Quaternion.identity) as GameObject;
            bomb.GetComponent<Rigidbody>().AddForce(throwForce, ForceMode.Impulse);
        }
    }
}