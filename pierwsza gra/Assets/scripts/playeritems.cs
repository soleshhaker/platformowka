using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class playeritems
{
    private static int speedpotion, score, bluedust, jumppotion, jump;


    public static int Speedpotion
    {
        get
        {
            return speedpotion;
        }
        set
        {
            speedpotion = value;
        }
    }
    public static int Jumppotion
    {
        get
        {
            return jumppotion;
        }
        set
        {
            jumppotion = value;
        }
    }
    public static int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }

    public static int Bluedust
    {
        get
        {
            return bluedust;
        }
        set
        {
           bluedust = value;
        }
    }

    public static int Jump
    {
        get
        {
            return jump;
        }
        set
        {
            jump = value;
        }
    }
   

}
