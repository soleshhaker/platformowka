using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class changecharacter : MonoBehaviour
    , IPointerClickHandler
{
    // Start is called before the first frame update
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject player;
    Vector3 position;
    void Start()
    {
      
    }

    // Update is called once per frame
    public void OnPointerClick(PointerEventData eventData)
    {
        position = player.transform.position;
        Destroy(player, 0.1f);

        Instantiate(character, position, Quaternion.identity);
    }
}
