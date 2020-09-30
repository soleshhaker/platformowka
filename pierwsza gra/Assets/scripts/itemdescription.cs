using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class itemdescription : MonoBehaviour
    , IPointerEnterHandler
    , IPointerExitHandler
{
    GameObject objToSpawn;
    GameObject ui;
    int istext = 0;
    public TextAlignmentOptions alignment { get; set; }

    void Awake()
    {
        ui = GameObject.Find("status");
        
    }

    void Update()
    {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (istext == 0)
        {
            objToSpawn = new GameObject("itemdesc");
            objToSpawn.AddComponent<Text>();
            objToSpawn.transform.SetParent(ui.transform);
            objToSpawn.transform.position = new Vector3(300, 0, 3);
            objToSpawn.GetComponent<RectTransform>().localPosition = new Vector3 (10, -170, 1);
            objToSpawn.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 60);
            objToSpawn.GetComponent<Text>().text = "Magical Dust that allows to reach more maximum speed";
            objToSpawn.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            istext = 1;


        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       objToSpawn.GetComponent<Text>().text = null;
       istext = 0;
       Destroy(objToSpawn);
    }
}