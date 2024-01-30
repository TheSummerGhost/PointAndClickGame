using System.Runtime.CompilerServices;
using System.Net;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OpenableContainer : MonoBehaviour
{

    public SpriteRenderer closed;
    public SpriteRenderer open;
    public GameObject[] itemsOnReveal = new GameObject[3];
    public bool isOpen = false;
    public string id;

    void Start()
    {
        closed.enabled = true;
        open.enabled = false;
        foreach (GameObject g in itemsOnReveal)
        {
            g.SetActive(false);
        }
        if(GameManager.Instance.CheckInDictionary(id))
        {
            bool itemState = GameManager.Instance.GetState(id);
            if(itemState)
            {
                closed.enabled = false;
                open.enabled = true;
                foreach (GameObject g in itemsOnReveal)
                {
                    if (g != null){
                                        g.SetActive(true);
                    }
                }
                isOpen = itemState;
            }
        } else 
        {
            GameManager.Instance.AddToDictionary(id, false);
        }
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        StartCoroutine(OpenClose());
    }

    public IEnumerator OpenClose() 
    {
        if (isOpen)
        {
            closed.enabled = true; 
            open.enabled = false;
            foreach (GameObject g in itemsOnReveal)
            {
                if(g != null)
                {
                    g.SetActive(false);
                }
            }
        } else 
        {
            closed.enabled = false;
            open.enabled = true;
            foreach (GameObject g in itemsOnReveal)
            {
                yield return new WaitForSeconds(0.2f);
                if (g != null)
                {
                    g.SetActive(true);
                }
            }
        }
        isOpen = !isOpen;
        GameManager.Instance.SetState(id, isOpen);
    }
}
