using UnityEngine;
using System.Collections;
using System;

class HighScore : IComparable<HighScore>
{
    public int Score { get; set; }
    public string Name { get; set; }
    public int ID { get; set; }
    public DateTime Date { get; set; }
    public HighScore(int id, int score, string name, DateTime data)
    {

        this.Score = score;
        this.Name = name;
        this.ID = id;
        this.Date = Date;
    }

    public int CompareTo(HighScore other)
    {
        if (other.Score < this.Score) //If the other score is less than this
        {
            return -1;
        }
        else if (other.Score > this.Score) //If the other score is larger than this
        {
            return 1;
        }
        else if (other.Date < this.Date) //If the scores are equal then we need to check the date
        {
            return -1;
        }
        else if (other.Date > this.Date)
        {
            return 1;
        }
        return 0;
    }
}

