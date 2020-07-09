using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runda2start : MonoBehaviour
{
    void tekst()
    {
        gate1.gatestatus = null;
    }
    void OnCollisionEnter(Collision col)
    {


        if (col.gameObject.tag == "Player")
        {

            Invoke("tekst", 2f);

        }


    }
}
