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
    public void gaterestart()
    {
        gate1.gatestatus = null;
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            key.GetComponent<Image>().enabled = true;
            keyslot.GetComponent<Image>().enabled = true;

            Player.key += 1;
            gate1.gatestatus = "You picked up a key";
            Invoke("gaterestart", 3);
            source = GetComponent<AudioSource>();
            source.Play();
            GetComponent<Collider>().enabled = false;
            GetComponentInChildren<MeshRenderer>().enabled = false;
            Destroy(gameObject, 3f);
        }
    }
}
