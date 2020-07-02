using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;


public class punkty : MonoBehaviour
{
    public static int scoreValue = 0;

    public Text score;
    // Use this for initialization
    void Start()
    {
        score = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Punkty: " + scoreValue;
    }
}