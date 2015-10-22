using UnityEngine;
using System.Collections;


public class Spawner : MonoBehaviour
{
   
    public GameObject topWall, bottomWall, leftWall, rightWall, backWall;
    public GameObject staticObject, bouncingNode;
    public GameObject bombObject;

    float buffer = 10.0f;

    [Range(0, 80)]
    public float BombPercentage;

    [Range(0f,3.0f)]
    public float SpawnTime;

    
    void Start()
    {
        InvokeRepeating("SpawnNode", 0.5f, SpawnTime);
    }

    void SpawnNode()
    {

        int number = Random.Range(1, 100);

        Vector3 location = new Vector3(Random.Range(leftWall.transform.position.x + buffer, rightWall.transform.position.x - buffer),
                                       Random.Range(topWall.transform.position.y - buffer, bottomWall.transform.position.y + buffer),
                                       backWall.transform.position.z - 5);


        if (number > 98)
        {
            GameObject node = Instantiate(bombObject, location, Quaternion.identity) as GameObject;
           
        }
        else if(number > 85)
        {
            GameObject node = Instantiate(bouncingNode, location, Quaternion.identity) as GameObject;
        }
        else
        {
            GameObject node = Instantiate(staticObject, location, Quaternion.identity) as GameObject;
        }
    }
}