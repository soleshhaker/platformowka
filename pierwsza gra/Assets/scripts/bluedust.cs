using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bluedust : MonoBehaviour
{
    GameObject dust;
    GameObject dustslot;
    void Start()
    {
        dust = GameObject.Find("Image");
        dustslot = GameObject.Find("InventorySlot1");
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.name == "Sphere")
        {
            dust.GetComponent<Image>().enabled = true;
            dustslot.GetComponent<Image>().enabled = true;
        }
    }
}
