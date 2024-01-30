using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class InnerDoor : MonoBehaviour
{

    public SpriteRenderer closedDoor;
    public SpriteRenderer openDoor;
    public string sceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        closedDoor.enabled = true;
        openDoor.enabled = false;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        StartCoroutine(OpeningDoorDisplay());
    }

    public IEnumerator OpeningDoorDisplay() 
    {
        closedDoor.enabled = false;
        openDoor.enabled = true;
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(sceneToLoad);
    }
}
