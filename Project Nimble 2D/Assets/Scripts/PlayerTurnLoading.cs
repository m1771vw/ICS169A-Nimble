using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerTurnLoading : MonoBehaviour
{

    public GameObject multiplayerData;
    private Text text;
    private SavedMultiplayerData script;
    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        multiplayerData = GameObject.Find("MultiplayerData");
        script = multiplayerData.GetComponent<SavedMultiplayerData>();
        script.setCurrentPlayersTurn(script.currentPlayerInt);
        text.text = script.currentPlayersTurn();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

