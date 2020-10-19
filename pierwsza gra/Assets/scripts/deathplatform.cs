using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class deathplatform : MonoBehaviour
{
   

    void OnCollisionEnter(Collision col)
    {
        
        if ( col.gameObject.tag == "Player")
        {
            
            Destroy(col.gameObject);
            SceneManager.LoadScene(0);
        }
    }
}
