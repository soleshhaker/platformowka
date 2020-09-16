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
    bool upgraded = false;

    void OnTriggerStay(Collider col)
    {
        obj = GameObject.Find("upgradetext");

        if (col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Return) && Player.score >= 300)
        {
            Debug.Log("skrypt");
            Player.score -= 300;
            source = GetComponent<AudioSource>();
            source.Play();
            Debug.Log("ulepszono");
            Player.jump += 2;
            upgraded = true;
            upgradetext.upgradestatus = "Jump upgraded";

            Destroy(obj, 2f);
            Destroy(gameObject, 0.1f);

        }
        if (col.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Return) && Player.score < 300 && upgraded == false)
        {
            upgradetext.upgradestatus = "You need at least 300 points";
            Debug.Log("kolizja");
        }
    }
}
