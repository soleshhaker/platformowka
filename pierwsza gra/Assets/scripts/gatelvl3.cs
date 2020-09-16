using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

public class gatelvl3 : MonoBehaviour


{
    public void gaterestart()
    {
        gate1.gatestatus = null;
    }



    void OnTriggerEnter(Collider col)
    {
        BoxCollider gatecolider;

        if (col.gameObject.tag == "Player" && Player.bluedust > 0)
        {
            gate1.gatestatus = "You can pass";
            Invoke("gaterestart", 3);
            gatecolider = GameObject.Find("gatecolider").GetComponent<BoxCollider>();
            gatecolider.enabled = false;
            Application.Quit();
        }

        if (col.gameObject.tag == "Player" && Player.bluedust == 0)
        {
            gate1.gatestatus = "You need blue dust";
            Invoke("gaterestart", 3);

        }
    }
}