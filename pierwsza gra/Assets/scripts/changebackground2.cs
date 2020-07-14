using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changebackground2 : MonoBehaviour
{

    private SpriteRenderer tlo;
    [SerializeField] private Sprite tlo1;

    // Start is called before the first frame update
    void Start()
    {
        tlo = GameObject.Find("tlo").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            tlo.sprite = tlo1;

            Debug.Log("zmianatla");
        }
    }
}
 