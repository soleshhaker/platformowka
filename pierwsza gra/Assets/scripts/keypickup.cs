using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keypickup : MonoBehaviour
{
    public static GameObject key;
    public static GameObject keyslot;
    AudioSource source;
    void Start()
    {
        key = GameObject.Find("Image4");
        keyslot = GameObject.Find("InventorySlot4");
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            key.GetComponent<Image>().enabled = true;
            keyslot.GetComponent<Image>().enabled = true;

            playeritems.Key += 1;
            source = GetComponent<AudioSource>();
            source.Play();

            Destroy(gameObject, 0.2f);
        }
    }
}
