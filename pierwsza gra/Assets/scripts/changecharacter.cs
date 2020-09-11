using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Cinemachine;

public class changecharacter : MonoBehaviour
    , IPointerClickHandler
{
    // Start is called before the first frame update
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject player;
    public GameObject vcam1;
    public GameObject vcam2;
    public GameObject vcam3;
    public GameObject vcam4;
    Vector3 position;
    static public bool ischaracterchanged;

    void Start()
    {
        
        vcam3 = GameObject.Find("vcam2");
        vcam4 = GameObject.Find("vcam1");
        ischaracterchanged = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        position = player.transform.position;
        Instantiate(character, position, Quaternion.identity);
        vcam1 = GameObject.Find("vcam1_2");
        vcam2 = GameObject.Find("vcam2_2");
        ischaracterchanged = true;
        Destroy(player, 0.1f);
        vcam2.SetActive(false);
        vcam3.SetActive(false);
        vcam4.SetActive(false);
        vcam1.SetActive(true);


      
    }
}
