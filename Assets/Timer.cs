using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
    private GUIText timeTF;
	public GameObject alertReference;

    void Start()
    {
        timeTF = gameObject.GetComponent<GUIText>();
        InvokeRepeating("ReduceTime", 1, 1);
    }
    
    void ReduceTime()
    {
        if (timeTF.text == "1")
        {
			/* Alert */
			
			Time.timeScale = 0;
			Instantiate(alertReference, new Vector3(0.5f, 0.5f, 0), transform.rotation);
			GetComponent<AudioSource>().Play();
			GameObject.Find("AppleGUI").GetComponent<AudioSource>().Stop();
		}
		
        timeTF.text = (int.Parse(timeTF.text) - 1).ToString();
    }

	void Reload()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
}
