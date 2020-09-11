using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

public class KillPlayer : MonoBehaviour

{
    public GameObject Player;
    AudioSource source;


    void OnCollisionEnter (Collision col)
    {
        Player = GameObject.FindWithTag("Player");
        source = GameObject.Find("deathsound").GetComponent<AudioSource>();
        if (col.gameObject.tag == "Player")
        {
            
            Destroy(Player);
            source.Play();
            playeritems.Score --;
        }
    }
}