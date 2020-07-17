using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using System.Collections.Specialized;

public class KillEnemy : MonoBehaviour

{
    AudioSource source;
    void OnCollisionEnter(Collision col)
    {
        float speed = 300.0f;
        if (col.gameObject.tag == "Player")
        {
            playeritems.Score += 30;
            source = GetComponent<AudioSource>();
            source.Play();

            GameObject.Find("player").GetComponent<Rigidbody>().AddForce(Vector3.up * speed);

            Destroy(transform.parent.parent.gameObject, 0.1f);
            
        }
    }
}