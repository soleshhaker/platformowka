using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using Cinemachine;
using System.Security.Cryptography;

public class camerascript2 : MonoBehaviour
{

    public GameObject player;
    public GameObject vcam1;
    public GameObject vcam2;


    void Start()
    {
        player = GameObject.Find("player");
        vcam1 = GameObject.Find("vcam1");
        vcam2 = GameObject.Find("vcam2");
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {

            vcam1.SetActive(true);
            vcam2.SetActive(false);

        }
    }

}