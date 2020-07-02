using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using Cinemachine;
using System.Security.Cryptography;

public class camerascript : MonoBehaviour
{

    public GameObject player;
    public GameObject vcam1;
    public GameObject vcam2;


    void Start()
    {
        player = GameObject.Find("Sphere");
        vcam1 = GameObject.Find("vcam1");
        vcam2 = GameObject.Find("vcam2");
    }

    void OnTriggerEnter(Collider col)
    {
        
        if (col.gameObject.name == "Sphere")
        {
            
            vcam1.SetActive(false);
            vcam2.SetActive(true);

        }

        

    }
    
}
