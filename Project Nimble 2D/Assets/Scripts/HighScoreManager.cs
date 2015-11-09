using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections.Generic;

public class HighScoreManager : MonoBehaviour {
    private string connectionString;
    private List<HighScore> highScores = new List<HighScore>();
    public GameObject scorePrefab;
    public int topRanks;
    public int saveScores;
    public Transform scoreParent;
    private string connection;
    private IDbConnection dbcon;
    private IDbCommand dbcmd;
    private IDataReader reader;
    

    // Use this for initialization
    void Start () {
        //connectionString = "URI=file:" + Application.persistentDataPath + "/scores3.sqlite";
        OpenDB("scores3.sqlite"); //IF OPENED, DATABASE RESET
        //CreateTable();
        //InsertScore("test123", 1000);
        ShowScores();
        DeleteExtraScore();
        //DeleteScore("oscar");
        //getScores();
        
	}
	
	// Update is called once per frame
	void Update () {
	
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
    /*
    private void getScores()
    {
        highScores.Clear();
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = "SELECT * FROM HighScores";

                dbCmd.CommandText = sqlQuery;
                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        highScores.Add(new HighScore(reader.GetInt32(0), reader.GetInt32(2), reader.GetString(1), reader.GetDateTime(3)));
                        //Debug.Log(reader.GetString(0));

                    }
                    dbConnection.Close();
                    reader.Close();
                }
            }
        }
        highScores.Sort();

    } */
    private void getScores()
    {
        highScores.Clear();

            //dbConnection.Open();
        using (dbcmd = dbcon.CreateCommand())
        {
            string sqlQuery = "SELECT * FROM HighScores";

            dbcmd.CommandText = sqlQuery;
            using (reader = dbcmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    highScores.Add(new HighScore(reader.GetInt32(0), reader.GetInt32(2), reader.GetString(1), reader.GetDateTime(3)));
                    //Debug.Log(reader.GetString(0));

                }
                dbcon.Close();
                reader.Close();
            }
        }
        
        highScores.Sort();

    }

    private void DeleteScore(int id)
    {
        //DELETE FROM Tscores WHERE name = "name"
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open();
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                string sqlQuery = string.Format("DELETE FROM HighScores WHERE PlayerID = \"{0}\"", id);
                dbCmd.CommandText = sqlQuery;
                dbCmd.ExecuteScalar();
                dbConnection.Close();

            }
        }
    }

    private void ShowScores()
    {
        getScores();
        for (int i = 0; i < topRanks; i++)
        {
            if (i <= highScores.Count - 1)
            {
                GameObject tmpObject = Instantiate(scorePrefab);
                HighScore tmpScore = highScores[i];
                tmpObject.GetComponent<HighScoreScript>().SetScore(tmpScore.Name, tmpScore.Score.ToString(), "#" + (i + 1).ToString());

                tmpObject.transform.SetParent(scoreParent);
                tmpObject.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            }

        }
    }

    public void CreateTable()
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

    } /*
    public void InsertScore(string name, int newScore)
    {
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            //Opens the connection
            dbConnection.Open();

            //Creates a database comment
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                //Creates a query for inserting the new score
                string sqlQuery = String.Format("INSERT INTO HighScores(Name,Score) VALUES(\"{0}\",\"{1}\")", name, newScore);

                dbCmd.CommandText = sqlQuery; //Gives the query to the commandtext
                dbCmd.ExecuteScalar(); //Executes the query
                dbConnection.Close();//Closes the connetcion


            }
        }
    } */
    /*
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
            //dbcon.Close();


        }
    }*/
    public void DeleteExtraScore()
    {
        getScores();
        if (saveScores <= highScores.Count)
        {
            int deleteCount = highScores.Count - saveScores;
            highScores.Reverse();
                //dbConnection.Open();
                using (dbcmd = dbcon.CreateCommand())
                {
                    for (int i = 0; i < deleteCount; i++)
                    {
                        string sqlQuery = string.Format("DELETE FROM HighScores WHERE PlayerID = \"{0}\"", highScores[i].ID);
                        dbcmd.CommandText = sqlQuery;
                        dbcmd.ExecuteScalar();
                    }

                    //dbConnection.Close();

                }
            
        }
    }
}
