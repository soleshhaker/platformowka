using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

public class goldcoin : MonoBehaviour

{
    AudioSource source;
    void OnTriggerEnter(Collider col)
    {
        source = GetComponent<AudioSource>();
        if (col.gameObject.name == "GoldCoin")
        {
            Destroy(col.transform.parent.gameObject);
            punkty.scoreValue += 20;
            source.Play();
        }
    }
}