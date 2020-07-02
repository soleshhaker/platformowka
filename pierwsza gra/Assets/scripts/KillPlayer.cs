using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

public class KillPlayer : MonoBehaviour

{
    public GameObject Player;



    void OnCollisionEnter (Collision col)
    {
        Player = GameObject.Find("Sphere");
        if (col.gameObject.name == "Sphere")
        {
            Destroy(Player);
            punkty.scoreValue--;
        }
    }
}