using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jumppotion : MonoBehaviour
{
    static public GameObject jmppotion;
    static public GameObject jumppotionslot;
    static public int jumpvalue;

    void Awake()
    {
        jumpvalue = 20;

    }
    void Start()
    {
        jmppotion = GameObject.Find("Image3");
        jumppotionslot = GameObject.Find("InventorySlot3");

    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            
            jmppotion.GetComponent<Image>().enabled = true;
            jumppotionslot.GetComponent<Image>().enabled = true;
            playeritems.Jumppotion += 1;

            Destroy(gameObject);
        }
    }
}
