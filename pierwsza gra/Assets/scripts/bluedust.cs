using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bluedust : MonoBehaviour
{
    public static GameObject dust;
    public static GameObject dustslot;
    AudioSource source;
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

            Player.bluedust += 1;
            source = GetComponent<AudioSource>();
            source.Play();

            Destroy(gameObject, 0.2f);
        }
    }
}
