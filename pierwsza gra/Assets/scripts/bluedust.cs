using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bluedust : MonoBehaviour
{
    public static GameObject dust;
    public static GameObject dustslot;
    void Start()
    {
        dust = GameObject.Find("Image");
        dustslot = GameObject.Find("InventorySlot1");
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            dust.GetComponent<Image>().enabled = true;
            dustslot.GetComponent<Image>().enabled = true;

            playeritems.Bluedust += 1;


            Destroy(gameObject);
        }
    }
}
