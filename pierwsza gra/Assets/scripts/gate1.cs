using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gate1 : MonoBehaviour
{
    public static string gatestatus;
    public TextMeshProUGUI gate;

    
    // Use this for initialization
    void Start()
    {
        gate = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        gate.text =  gatestatus;
    }
}
