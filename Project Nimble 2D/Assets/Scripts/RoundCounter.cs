using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class RoundCounter : MonoBehaviour {

    public GameObject multiplayerData;
    private Text text;
    private SavedMultiplayerData script;
    // Use this for initialization
    void Start () {
        text = GetComponent<Text>();
        multiplayerData = GameObject.Find("MultiplayerData");
        script = multiplayerData.GetComponent<SavedMultiplayerData>();
        text.text = text.text + " " + script.getRoundCounter();
        script.inMultiplayer = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
