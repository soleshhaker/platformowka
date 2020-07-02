using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class trampolina : MonoBehaviour
{
    public float springForce = 1000;
    private Collision collision;
    private bool bouncing = false;
    AudioSource source;

    void OnCollisionEnter(Collision coll)
    {
        if (!bouncing)
        {
            bouncing = true;
            collision = coll;
            source = GetComponent<AudioSource>();
            source.Play();
        }
    }

    void FixedUpdate()
    {
        if (bouncing)
        {
            var rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(0, 0, 0);
            rb.AddForce(new Vector3(0f, springForce));
            bouncing = false;
        }
    }
}
