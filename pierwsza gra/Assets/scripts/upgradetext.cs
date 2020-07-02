using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class upgradetext : MonoBehaviour
{
    public static string upgradestatus;
    public TextMeshProUGUI upgrade;


    // Use this for initialization
    void Start()
    {
        upgrade = GetComponent<TextMeshProUGUI>();
        upgradestatus = "Press enter to upgrade jump ability for 300 points";
    }

    // Update is called once per frame
    void Update()
    {
        upgrade.text = upgradestatus;
    }
}
