using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;


public class hp : MonoBehaviour
{

    public Text hpstatus;
    // Use this for initialization
    void Start()
    {
        hpstatus = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        hpstatus.text = "HP: " + Player.hp;

    }
}