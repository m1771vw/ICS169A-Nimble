using UnityEngine;
using System.Collections;
using Mono.Data.Sqlite;
using System.Text;
using System;
using System.Data;
using System.IO;
using System.Collections.Generic;

public class ScoreController : MonoBehaviour
{
    //HighScoreManager other;
    private string connection;
    private IDbConnection dbcon;
    private IDbCommand dbcmd;
    private IDataReader reader;
    private StringBuilder builder;
    private HighScoreManager other;
    private string connectionString;
    public GUIText scoreText;
	private GUIText TimerTf;
    public int score;
	public GameObject timerData;
	private Timer timer;
    // Use this for initialization
    void Start()
    {
		//TimerTf = gameObject.GetComponent<GUIText>();
		//InvokeRepeating("ReduceTime", 1, 1);
        //HighScoreManager db = GetComponent<HighScoreManager>();

        UpdateScore();
        OpenDB("scores3.sqlite");
        //connectionString = "URI=file:" + Application.persistentDataPath + "/scores3.sqlite";
        CreateTable();
        //other.InsertScore("test", score);
        // scoreText = GameObject.Find("Score").GetComponent<GUIText>();
		timerData = GameObject.Find ("Timer");
		timer = timerData.GetComponent<Timer> ();

        
    }
	void Update()
	{
		checkTimer ();
	}
	public void checkTimer()
	{
		Debug.Log ("Checking Score before it hits 0: " + score);
		if (timer.getIsZero()) 
		{
			Debug.Log ("Trying to add data");
			AddData();
		}
	}
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();

    }
	/*
	public void ReduceTime()
	{

		Debug.Log ("Checking score: " + score);
		if (TimerTf.text == "1") 
		{
			Debug.Log ("Before: "+ score);
			AddData ();
			Debug.Log ("After: " + score);

			//InsertScore ("YOU",score);
			//Application.LoadLevel ("endscreen");
			//InsertScore ("YOU", 10);
		}
		TimerTf.text = (int.Parse(TimerTf.text) - 1).ToString();
	} */

	public void AddData()
	{
		InsertScore ("YOU", score);
		Application.LoadLevel ("endscreen");
	}

    public void UpdateScore()
    {
        //HighScoreManager db = GetComponent<HighScoreManager>();
        scoreText.text = "Score: " + score;

        //checkScore();
		/*		
        if (score == 5)
        {
            //other.InsertScore("test", 200);
            InsertScore("oscar6654", score);

            //CloseDB();
            Application.LoadLevel("endscreen");
            //other.InsertScore("test", score);
        } */
    }
    
    public void OpenDB(string p)
    {
        Debug.Log("Call to OpenDB:" + p);
        // check if file exists in Application.persistentDataPath
        string filepath = Application.persistentDataPath + "/" + p;
        if (!File.Exists(filepath))
        {
            Debug.LogWarning("File \"" + filepath + "\" does not exist. Attempting to create from \"" +
                             Application.dataPath + "!/assets/" + p);
            // if it doesn't ->
            // open StreamingAssets directory and load the db -> 
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/" + p);
            while (!loadDB.isDone) { }
            // then save to Application.persistentDataPath
            File.WriteAllBytes(filepath, loadDB.bytes);
        }

        //open db connection
        connection = "URI=file:" + filepath;
        Debug.Log("Stablishing connection to: " + connection);
        dbcon = new SqliteConnection(connection);
        dbcon.Open();
    } 
    
    public void CloseDB()
    {
        reader.Close(); // clean everything up
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close();
        dbcon = null;
    } 

    
    public void InsertScore(string name, int newScore)
    {

        //Opens the connection
        //dbConnection.Open();

        //Creates a database comment
        using (dbcmd = dbcon.CreateCommand())
        {
            //Creates a query for inserting the new score
            string sqlQuery = String.Format("INSERT INTO HighScores(Name,Score) VALUES(\"{0}\",\"{1}\")", name, newScore);

            dbcmd.CommandText = sqlQuery; //Gives the query to the commandtext
            dbcmd.ExecuteScalar(); //Executes the query
            //dbConnection.Close();//Closes the connetcion
            dbcon.Close();


        }
    } 
    
    void CreateTable()
    {
        //Creates the connection

            //Opens the connection
            //dbConnection.Open();

            //Creates a command so that we can execute it on the database
            using (dbcmd = dbcon.CreateCommand())
            {
                //Create the query 
                string sqlQuery = String.Format("CREATE TABLE if not exists HighScores (PlayerID INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL  UNIQUE , Name TEXT NOT NULL , Score INTEGER NOT NULL , Date DATETIME NOT NULL  DEFAULT CURRENT_DATE)");

                //Gives the sqlQuery to the command
                dbcmd.CommandText = sqlQuery;

                //Executes the commnad
                dbcmd.ExecuteScalar();

                //Closes the connections
                //dbConnection.Close();
            }
        
    }

}
