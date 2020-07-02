using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using System.Collections.Specialized;

public class upgrade1 : MonoBehaviour
{
    AudioSource source;


    void OnTriggerStay(Collider col)
    {
        Debug.Log("kolizja");

        if (col.gameObject.name == "Sphere" && Input.GetKeyDown(KeyCode.Return) && punkty.scoreValue >= 300)
        {
            Debug.Log("skrypt");
            punkty.scoreValue -= 300;
            source = GetComponent<AudioSource>();
            source.Play();

            CharacterControls.jumpHeight += 2;

            Destroy(gameObject, 0.1f);

        }
    }
}
