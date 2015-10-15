using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{
    public GUIText timeTF;
	public GameObject alertReference;
    //public Button endText;

    public void Start()
    {
        timeTF = gameObject.GetComponent<GUIText>();
        InvokeRepeating("ReduceTime", 1, 1);
    }
    
    public void ReduceTime()
    {
        if (timeTF.text == "1")
        {
			/* Alert */
			
			Time.timeScale = 0;
            Instantiate(alertReference, new Vector3(0.5f, 0.5f, 0), transform.rotation);
            //endText = GameObject.Find("alertReference").GetComponent<Button>();
            GetComponent<AudioSource>().Play();
			GameObject.Find("AppleGUI").GetComponent<AudioSource>().Stop();
            Application.LoadLevel("endscreen");
		}
		
        timeTF.text = (int.Parse(timeTF.text) - 1).ToString();
        //Application.LoadLevel("start_menu");
    }

	//public void Reload()
	//{
	//	Application.LoadLevel ("start_menu");
	//}
}
