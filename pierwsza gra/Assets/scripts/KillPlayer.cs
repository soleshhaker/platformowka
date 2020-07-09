using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

public class KillPlayer : MonoBehaviour

{
    public GameObject Player;



    void OnCollisionEnter (Collision col)
    {
        Player = GameObject.Find("player");
        if (col.gameObject.tag == "Player")
        {
            Destroy(Player);
            punkty.scoreValue--;
        }
    }
}