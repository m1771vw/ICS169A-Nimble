using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{
    private GUIText timeTF;
    public GameObject multiplayerData;
    private SavedMultiplayerData script;

    public void Start()
    {
        timeTF = gameObject.GetComponent<GUIText>();
        InvokeRepeating("ReduceTime", 1, 1);
        multiplayerData = GameObject.Find("MultiplayerData");
        script = multiplayerData.GetComponent<SavedMultiplayerData>();
    }
    
    public void ReduceTime()
    {
        
        if (timeTF.text == "0")
        {
            int playersPassed = 0;
            for (int i = 0; i < script.numberOfPlayers; i++)
            {
                if (script.getPassOrFail(i) == true)
                {
                    ++playersPassed;
                    return;
                }
            }
            if(playersPassed == 1)
            {
                //single winner
                Application.LoadLevel(8);
            }

            //find next player loop
            bool playerFound = false;
            while (playerFound == false)
            {
                if ((script.currentPlayerInt + 1) >= script.numberOfPlayers)
                {
                    script.currentPlayerInt = 0;
                }
                //next player load
                if (script.getPassOrFail(script.currentPlayerInt + 1) == false)
                {
                    script.currentPlayerInt += 1;
                }
                else
                {
                    playerFound = true;
                    Application.LoadLevel(7);
                }
            }     
        }
		
        timeTF.text = (int.Parse(timeTF.text) - 1).ToString();

    }

}
