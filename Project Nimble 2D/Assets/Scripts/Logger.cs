using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class Logger : MonoBehaviour {

    //string declarations for storing the current directory, the log directory, and the item spawning log file locations.
    string currentDirectory, logDirectory,itemSpawnDirectory, itemDestroyDirectory, itemSpawnLogPath, itemDestroyLogPath;
    
    //DateTime object to get current time for timestamps.
    DateTime currentTime;

	// Use this for initialization
	void Start () {

        currentTime = DateTime.Today;

        //assigning the variables. current directory is getting the current directory.
        currentDirectory = Directory.GetCurrentDirectory();

        //appending "\\Logs\\" to the end of current directory to allow for creating the directory if it doesn't exist
        logDirectory = currentDirectory + "\\Logs\\";

        itemDestroyDirectory = logDirectory + "\\ItemDestroy\\";

        //appending \\ItemSpawnTimes\\ to end of log directory to allow for folders per log files
        itemSpawnDirectory = logDirectory + "\\ItemSpawn\\";

        //appending the name of the file to the logdirectory string to allow adding to the text file or creating it
        itemSpawnLogPath = itemSpawnDirectory + "ItemSpawn_" + currentTime.ToString("MM-dd-yyyy") + ".txt";

        itemDestroyLogPath = itemDestroyDirectory + "ItemDestroy_" + currentTime.ToString("MM-dd-yyyy") + ".txt";

        //checking if the directory exists. if not, create the directory.
        if (!Directory.Exists(logDirectory))
        {
            Directory.CreateDirectory(logDirectory);
        }
        
        if (!Directory.Exists(itemSpawnDirectory))
        {
            Directory.CreateDirectory(itemSpawnDirectory);
        }
        
        if (!Directory.Exists(itemDestroyDirectory))
        {
            Directory.CreateDirectory(itemDestroyDirectory);
        }
        

        //checking if the file exists. if not, create the file.
        if (!File.Exists(itemSpawnLogPath))
        {
            File.Create(itemSpawnLogPath);
            
        }
        if (!File.Exists(itemDestroyLogPath))
        {
            File.Create(itemDestroyLogPath);

        }
        
	}
	
	

    public void writeItemSpawn(string message)
    {
        //get current time hh:mm:ss
        currentTime = DateTime.Now;
        
        //create the file writer
        TextWriter tw = new StreamWriter(itemSpawnLogPath, true);
        
        //write the message to the file
        tw.WriteLine(currentTime.TimeOfDay.ToString()+" "+message);
        
        //close the file
        tw.Close();
    
    }
    
    public void writeItemDestroy(string message)
    {
        //get current time hh:mm:ss
        currentTime = DateTime.Now;

        //create the file writer
        TextWriter tw = new StreamWriter(itemSpawnLogPath, true);

        //write the message to the file
        tw.WriteLine(currentTime.TimeOfDay.ToString() + " " + message);

        //close the file
        tw.Close();

    }

    public void writeItemSpawn(GameObject node)
    {
        //get current time hh:mm:ss
        currentTime = DateTime.Now;

        //create the file writer
        TextWriter tw = new StreamWriter(itemSpawnLogPath, true);

        //write the message to the file
        tw.WriteLine(currentTime.TimeOfDay.ToString() + " " + node.name+" spawned at "+node.transform.position);

        //close the file
        tw.Close();

    }

    public void writeItemDestroy(GameObject node)
    {
        Debug.Log("destroy called");
        //get current time hh:mm:ss
        currentTime = DateTime.Now;

        //create the file writer
        TextWriter tw = new StreamWriter(itemDestroyLogPath, true);

        //write the message to the file
        tw.WriteLine(currentTime.TimeOfDay.ToString() + " " + node.name + " destroyed at " + node.transform.position);

        //close the file
        tw.Close();

    }
}
