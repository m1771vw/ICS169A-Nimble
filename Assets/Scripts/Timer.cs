using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{
    private GUIText timeTF;
	public GameObject alertReference;
    //public Button endText;

    public void Start()
    {
        timeTF = gameObject.GetComponent<GUIText>();
        InvokeRepeating("ReduceTime", 1, 1);
    }
    
    public void ReduceTime()
    {
        if (timeTF.text == "0")
        {
			/* Alert */
			
			//Time.timeScale = 0;
            //Reload();
            //Instantiate(alertReference, new Vector3(0.5f, 0.5f, 0), transform.rotation);
            GetComponent<AudioSource>().Play();
			//GameObject.Find("AppleGUI").GetComponent<AudioSource>().Stop();
            //Application.LoadLevel(Application.loadedLevel);
            Application.LoadLevel("endscreen");
        }
		
        timeTF.text = (int.Parse(timeTF.text) - 1).ToString();
        //Invoke("Reload", 3);
        //Reload();
        //Application.LoadLevel("start_menu");
    }

	public void Reload()
	{

        //Application.LoadLevel(Application.loadedLevel);
    }
}
