using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class itemdescription2 : MonoBehaviour
    , IPointerEnterHandler
    , IPointerExitHandler
    , IPointerClickHandler
{
    GameObject objToSpawn;
    GameObject ui;
    int istext;
    float speed;
    public TextAlignmentOptions alignment { get; set; }
    AudioSource source;
    void Update()
    {
       
        
    }

    void Awake()
    {
        ui = GameObject.Find("status");
        int istext = 0;
        speed = speedpotion.speedvalue;
        // Debug.Log(speed);
    }

    void usepotion(float speed)
    {
        Player.speed += speed;
    }

    void endpotion(float speed)
    {
        Player.speed -= speed;
    }
 
    public void OnPointerEnter(PointerEventData eventData)
    {
        ui = GameObject.Find("status");

        if (istext == 0)
        {
            objToSpawn = new GameObject("itemdesc");
            objToSpawn.AddComponent<Text>();
            objToSpawn.transform.SetParent(ui.transform);
            objToSpawn.transform.position = new Vector3(300, 0, 3);
            objToSpawn.GetComponent<RectTransform>().localPosition = new Vector3(10, -170, 1);
            objToSpawn.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 60);
            objToSpawn.GetComponent<Text>().text = "Potion than enhances speed, lasts for 30 seconds (Click to use)";
            objToSpawn.GetComponent<Text>().font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            istext = 1;


           // Debug.Log(Player.speedpotion);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
         objToSpawn.GetComponent<Text>().text = null;
         istext = 0;
         Destroy(objToSpawn);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ui = GameObject.Find("status");
        Debug.Log(speed);
        source = GetComponent<AudioSource>();
        source.Play();
        objToSpawn.GetComponent<Text>().text = "Potion used!";
        usepotion(speed);
        
    //  Debug.Log("potion used");

        Invoke("endpotion(speed)", 30);
        Player.speedpotion -= 1;
        istext = 1;
        if (Player.speedpotion == 0)
        {


            GameObject.Find("Image2").GetComponent<Image>().enabled = false;
            GameObject.Find("Image2text").GetComponent<TextMeshProUGUI>().enabled = false;
            GameObject.Find("InventorySlot2").GetComponent<Image>().enabled = false;
            
        }

        
    }
}