using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speedpotion : MonoBehaviour
{
    static public GameObject spdpotion;
    static public GameObject speedpotionslot;
    static public float speedvalue;

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

        if (col.gameObject.name == "Sphere")
        {
            spdpotion.GetComponent<Image>().enabled = true;
            speedpotionslot.GetComponent<Image>().enabled = true;
            inventory.speedpotionobtained += 1;

            Destroy(gameObject);
        }
    }
}
