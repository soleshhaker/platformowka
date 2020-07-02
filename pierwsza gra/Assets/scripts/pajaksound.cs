using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

public class pajaksound : MonoBehaviour

{

    AudioSource source;
    void OnTriggerEnter(Collider coll)
    {
      
        if (coll.gameObject.name == "Sphere")
        {
            source = GetComponent<AudioSource>();
            source.Play();

            
            Destroy(gameObject, 0.1f);
        }
    }
}