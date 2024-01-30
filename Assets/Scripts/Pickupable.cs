using System.Runtime.CompilerServices;
using System.Collections;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pickupable : MonoBehaviour
{
    public InventoryItem itemToPickUp;

    public SpriteRenderer spriteRenderer;

    public BoxCollider2D boxCollider;

    public string id;

    public void Start() 
    {
        //check if ID is in dictionary, if it is get the state, if not add yourself to dict
        if(GameManager.Instance.CheckInDictionary(id))
        {
            bool itemState = GameManager.Instance.GetState(id);
            Debug.Log(itemState);
            if(itemState)
            {
                Destroy(this.gameObject);
            }
        } else 
        {
            GameManager.Instance.AddToDictionary(id, false);
        }
        boxCollider = GetComponent<BoxCollider2D>();
    }
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) 
        {
            return;
        }
            InventoryManager.Instance.addToInventory(itemToPickUp);
            GameManager.Instance.SetState(id, true);
            FadeOut();
            boxCollider.enabled = false;
            Debug.Log("here");
            
    }

    public void FadeOut()
    {
        StartCoroutine(SpriteFade(0.0f, 0.5f));
    }

    IEnumerator SpriteFade(float target, float duration)
    {
        float currentAlpha = GetComponent<SpriteRenderer>().color.a;
        for (float t = 0.0f; t<1.0f; t += Time.deltaTime / duration)
        {
            Color newColor = new Color(1,1,1, Mathf.Lerp(currentAlpha, target, t));
            GetComponent<SpriteRenderer>().color = newColor;
            yield return null;
        }
    }
}
