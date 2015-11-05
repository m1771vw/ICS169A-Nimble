using UnityEngine;
using System.Collections;

public class SavedMultiplayerData : MonoBehaviour {
    public bool inMultiplayer = false;
    public static SavedMultiplayerData Instance;
    public int roundCounter = 1;
    public int numberOfPlayers = 0;
    public int currentPlayerInt = 0;
    public int firstPlayer = 0;
    public int lastPlayer;
    public string currentPlayerTurn;
    public bool[] passOrFail = new bool[99];
    public string[] players = new string[99];

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    
	// Use this for initialization
	void Start () {

	}

    public void setNumberOfPlayers(int i)
    {
        numberOfPlayers = i;
    }

    public void setRoundCounter(int i)
    {
        roundCounter = i;
    }

    public int getRoundCounter()
    {
        return roundCounter;
    }

    public string currentPlayersTurn()
    {
        return currentPlayerTurn;
    }

    public void setCurrentPlayersTurn(int i)
    {
        currentPlayerTurn = players[i];
    }

    public string getSpecificPlayer(int i)
    {
        if (i > numberOfPlayers)
        {
            return "none";
        }
        else
        {
            return players[i];
        }
    }

    public void setFail(int i)
    {
        passOrFail[i] = false;
    }

    public bool getPassOrFail(int i)
    {
        return passOrFail[i];
    }

    public void setCurrentPlayerInt(int i)
    {
        currentPlayerInt = i;
    }

    //set initail data
    void OnLevelWasLoaded(int level)
    {
        if (level == 0)
        {
            Destroy(this.gameObject);
        }
        if (level == 3  && roundCounter == 1)
        {
            for(int i = 0; i < numberOfPlayers; i++)
            {
                players[i] = "Player " + (i + 1);
                passOrFail[i] = true;
            }
            currentPlayerTurn = players[0];
            lastPlayer = numberOfPlayers - 1;
        }
    }

        // Update is called once per frame
        void Update()
    {
    }
}
