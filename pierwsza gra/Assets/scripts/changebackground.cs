using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changebackground : MonoBehaviour
{
    
    private SpriteRenderer tlo;
  
 void destroy()
    {
        Destroy(gameObject, 2f);
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            tlo = GameObject.Find("tlo3").GetComponent<SpriteRenderer>();


            Color c = tlo.material.color;

            c.a = 0f;

            tlo.material.color = c;

            StartCoroutine("FadeOut");
            Debug.Log("zmianatla");
            destroy();
        }
    }
    IEnumerator FadeOut()

    {

        for (float f = 0f; f <= 1f; f += 0.05f)

        {

            Color c = tlo.material.color;

            c.a = f;

            tlo.material.color = c;

            yield return new WaitForSeconds(0.05f);

        }

    }    
}
