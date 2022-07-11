using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore
{
    private int pos;
    private int score;
    private string name;
    public Highscore(int pos,int score,string name)
    {
        this.pos = pos;
        this.score = score;
        this.name = name;
    }
    public int GetPos()
    {
        return pos;
    }
    public int GetScore()
    {
        return score;
    }
    public string GetName()
    {
        return name;
    }
}

