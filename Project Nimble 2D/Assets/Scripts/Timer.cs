using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{
    private GUIText timeTF;
	public GameObject alertReference;
	public bool isZero = false;


    public void Start()
    {
		//ScoreController db = GetComponent<ScoreController>;
        timeTF = gameObject.GetComponent<GUIText>();
        InvokeRepeating("ReduceTime", 1, 1);
    }

    public void ReduceTime()
    {

        if (timeTF.text == "0")
        {
			isZero = true;
        }
		
		timeTF.text = (int.Parse(timeTF.text) - 1).ToString();



    }

	public bool getIsZero()
	{
		return isZero;
	}








}
