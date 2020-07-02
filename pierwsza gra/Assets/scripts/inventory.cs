using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class inventory : MonoBehaviour
{
    public Canvas CanvasObject; // Assign in inspector
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