using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speedpotion : MonoBehaviour
{
    static public GameObject spdpotion;
    static public GameObject speedpotionslot;
    static public float speedvalue;
    AudioSource source;
    void Awake()
    {
        speedvalue = 2f;

    }
    void Start()
    {
        spdpotion = GameObject.Find("Image2");
        speedpotionslot = GameObject.Find("InventorySlot2");
       
    }

    void OnTriggerEnter(Collider col)
    {
        source = GetComponent<AudioSource>();
        if (col.gameObject.tag == "Player")
        {
            spdpotion.GetComponent<Image>().enabled = true;
            speedpotionslot.GetComponent<Image>().enabled = true;
            playeritems.Speedpotion += 1;
            source.Play();

            Destroy(gameObject, 0.1f);
        }
    }
}
