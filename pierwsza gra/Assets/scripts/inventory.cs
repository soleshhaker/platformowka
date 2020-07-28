using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class inventory : MonoBehaviour
{
    public Canvas CanvasObject; 
    int isinventoryon = 0;
    void Start()
    {
        CanvasObject = GetComponent<Canvas>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && isinventoryon == 0)
        {
            GetComponent<CanvasGroup>().alpha = 0f;
            GetComponent<CanvasGroup>().interactable = false;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
            isinventoryon = 1;
            if (playeritems.Bluedust > 0)
            {
                bluedust.dust.GetComponent<Image>().raycastTarget = true;
                bluedust.dust.GetComponent<Image>().raycastTarget = true;
            }
            if (playeritems.Speedpotion > 0)
            {
                Debug.Log("slot on");
                GameObject.Find("Image2").GetComponent<Image>().enabled = true;
                GameObject.Find("Image2").GetComponent<Image>().raycastTarget = true;
                GameObject.Find("InventorySlot2").GetComponent<Image>().enabled = true;
                GameObject.Find("InventorySlot2").GetComponent<Image>().raycastTarget = true;
            }
            if (playeritems.Jumppotion > 0)
            {
                Debug.Log("slot on");
                GameObject.Find("Image3").GetComponent<Image>().enabled = true;
                GameObject.Find("Image3").GetComponent<Image>().raycastTarget = true;
                GameObject.Find("InventorySlot3").GetComponent<Image>().enabled = true;
                GameObject.Find("InventorySlot3").GetComponent<Image>().raycastTarget = true;
            }


        }
        else if (Input.GetKeyUp(KeyCode.Escape) && isinventoryon == 1)
        {

            GetComponent<CanvasGroup>().alpha = 1f;
            GetComponent<CanvasGroup>().interactable = true;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            isinventoryon = 0;
        }
    }
}