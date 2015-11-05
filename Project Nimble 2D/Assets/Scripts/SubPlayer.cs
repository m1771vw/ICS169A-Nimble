using UnityEngine;
using System.Collections;


public class SubPlayer : MonoBehaviour
{

    public GameObject savedPlayerCount;
    private SavedMultiplayerData script;
    private GUIText playerCount;
    private int playersInt; //loads to other scenes

    // Use this for initialization
    void Start()
    {
        playerCount = GameObject.Find("Number").GetComponent<GUIText>();
        script = savedPlayerCount.GetComponent<SavedMultiplayerData>();
    }

    void OnMouseDown()
    {
        playersInt = int.Parse(playerCount.text) - 1;
        script.setNumberOfPlayers(playersInt);
        playerCount.text = (int.Parse(playerCount.text) - 1).ToString();
    }


}
