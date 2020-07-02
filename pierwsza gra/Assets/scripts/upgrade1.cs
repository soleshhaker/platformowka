using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using System.Collections.Specialized;

public class upgrade1 : MonoBehaviour
{
    AudioSource source;

    GameObject obj;
    void OnTriggerStay(Collider col)
    {
        obj = GameObject.Find("upgradetext");

        if (col.gameObject.name == "Sphere" && Input.GetKeyDown(KeyCode.Return) && punkty.scoreValue >= 300)
        {
            Debug.Log("skrypt");
            punkty.scoreValue -= 300;
            source = GetComponent<AudioSource>();
            source.Play();
            Debug.Log("ulepszono");
            CharacterControls.jumpHeight += 2;
            upgradetext.upgradestatus = "Jump upgraded";

            Destroy(obj, 2f);
            Destroy(gameObject, 0.1f);

        }
       // else if (col.gameObject.name == "Sphere" && Input.GetKeyDown(KeyCode.Return) && punkty.scoreValue < 300)
       // {
        //    upgradetext.upgradestatus = "You need at least 300 points";
        //    Debug.Log("kolizja");
        //}
    }
}
