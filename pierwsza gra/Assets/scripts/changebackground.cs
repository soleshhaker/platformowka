using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changebackground : MonoBehaviour
{
    
    private SpriteRenderer tlo;
  
 
    // Start is called before the first frame update
    void Start()
    {
        tlo = GameObject.Find("tlo2").GetComponent<SpriteRenderer>();


        Color c = tlo.material.color;

        c.a = 0f;

        tlo.material.color = c;

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            
            StartCoroutine("FadeOut");
            Debug.Log("zmianatla");
           // hit1 = true;
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



    
    

    // void Update()
    // {

    //  if (hit1)
    //  {
    //    tlo.color = new Color(1f, 1f, 1f, Mathf.SmoothDamp(0f, 1f, ref speed, max));
    // }
    // }       
}
