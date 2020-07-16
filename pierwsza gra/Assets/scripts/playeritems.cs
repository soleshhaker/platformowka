using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class playeritems
{
    private static int speedpotion, score, bluedust, points;

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

}
