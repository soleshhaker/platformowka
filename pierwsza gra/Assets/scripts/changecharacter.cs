using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Cinemachine;

public class changecharacter : MonoBehaviour
    , IPointerClickHandler
{
    // Start is called before the first frame update
    [SerializeField] private GameObject player;
    Vector3 position;
    static public bool ischaracterchanged;
    public Avatar female;
    public Avatar male;

    void Awake()
    {
        
       
        ischaracterchanged = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
 
            player.transform.GetChild(0).gameObject.SetActive(false);
            player.transform.GetChild(1).gameObject.SetActive(true);
            player.GetComponent<Animator>().avatar = female;
            ischaracterchanged = true;


    }
}
