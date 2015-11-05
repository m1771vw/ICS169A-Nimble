using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{
    private GUIText timeTF;
    public GameObject multiplayerData;
    private SavedMultiplayerData data;

    public void Start()
    {
        timeTF = gameObject.GetComponent<GUIText>();
        InvokeRepeating("ReduceTime", 1, 1);
        multiplayerData = GameObject.Find("MultiplayerData");
        data = multiplayerData.GetComponent<SavedMultiplayerData>();
    }
    
    public void ReduceTime()
    {
        
        if (timeTF.text == "1")
        {
            if (data.firstPlayer == data.lastPlayer)
            {
                //all failed
                Application.LoadLevel("SingleWinner");
            }
            else if (data.currentPlayerInt == data.lastPlayer)
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
                    data.currentPlayerInt = i + 1;
                    Application.LoadLevel("Pass");
                    break;
                }
            }
        }
        timeTF.text = (int.Parse(timeTF.text) - 1).ToString();
    }

}
