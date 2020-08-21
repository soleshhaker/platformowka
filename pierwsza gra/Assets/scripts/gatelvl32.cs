using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

public class gatelvl32 : MonoBehaviour


{
    public void gaterestart()
    {
        gate1.gatestatus = null;
    }



    void OnTriggerEnter(Collider col)
    {
        int key = playeritems.Key;
        BoxCollider gatecolider;
        
        if (col.gameObject.tag == "Player" && key > 0)
        {
            gate1.gatestatus = "You can pass";
            Invoke("gaterestart", 3);
            gatecolider = GameObject.Find("gatecolider2").GetComponent<BoxCollider>();
            gatecolider.enabled = false;
            
        }

        if (col.gameObject.tag == "Player" && key == 0)
        {
            gate1.gatestatus = "You need a key";
            Invoke("gaterestart", 3);

        }
    }
}