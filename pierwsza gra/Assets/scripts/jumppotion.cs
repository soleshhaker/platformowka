using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jumppotion : MonoBehaviour
{
    static public GameObject jmppotion;
    static public GameObject jumppotionslot;
    static public int jumpvalue;
    AudioSource source;
    void Awake()
    {
        jumpvalue = 2;

    }
    void Start()
    {
        jmppotion = GameObject.Find("Image3");
        jumppotionslot = GameObject.Find("InventorySlot3");

    }

    void OnTriggerEnter(Collider col)
    {
        source = GetComponent<AudioSource>();
        if (col.gameObject.tag == "Player")
        {
            
            jmppotion.GetComponent<Image>().enabled = true;
            jumppotionslot.GetComponent<Image>().enabled = true;
            Player.jumppotion += 1;
            source.Play();
            Destroy(gameObject, 0.1f);
        }
    }
}
