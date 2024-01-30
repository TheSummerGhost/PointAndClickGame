using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EscapeDoor : MonoBehaviour
{

    public SpriteRenderer lockedDoor;
    public SpriteRenderer unlockedDoor;
    public InventoryItem key;

    public GameObject successPopUp;
    // Start is called before the first frame update
    void Start()
    {   
        successPopUp.SetActive(false);
        lockedDoor.enabled = true;
        unlockedDoor.enabled = false;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (InventoryManager.Instance.HasItem(key))
        {
            StartCoroutine(OpeningDoorDisplay());
        } else 
        {
            PopUpTextBox message = FindObjectOfType<PopUpTextBox>();
            if (message != null) {
                message.displayMessage("I need a key to open that");
            }
        }
    }


    public IEnumerator OpeningDoorDisplay() 
    {
        lockedDoor.enabled = false;
        unlockedDoor.enabled = true;
        yield return new WaitForSeconds(1.0f);
        successPopUp.SetActive(true);
    }
}
