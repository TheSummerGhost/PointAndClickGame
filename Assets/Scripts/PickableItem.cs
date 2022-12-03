using System.Security.Cryptography;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//This script manages the behaviour of picking up items

[RequireComponent(typeof(Fade))]
public class PickableItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Fade fader;
    public InventoryItem chosenItem;
    private bool chosen = false;

    private Vector2 originalPosition;

    void Start()
    {
        fader = GetComponent<Fade>();
        originalPosition = transform.position;
    }

    // void Update() {
    //     if (hover) {
    //         Vibrate();
    //     }
    // }

    void OnPickUp() {
        if (chosen) {
        } else {

            Debug.Log("You have picked up " + chosenItem.itemName);
            InventoryManager inventory = FindObjectOfType<InventoryManager>();
            if (inventory != null) {
                if (inventory.addToInventory(chosenItem)) {
                    fader.Hide();
                    chosen = true;
                }
            }
        }
    }

    public IEnumerator Vibrate() {
        do {
            Vector2 updatedPosition = originalPosition;
            updatedPosition.x += Random.Range(-0.02f, 0.02f);
            updatedPosition.y += Random.Range(-0.02f, 0.02f);
            transform.position = updatedPosition;
            yield return new WaitForSeconds(0.05f);
        } 
        while (true);
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine(Vibrate());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left) {
            Debug.Log("Left click");
            OnPickUp();
        }
        else if (eventData.button == PointerEventData.InputButton.Right) {
            Debug.Log(chosenItem.description);
            ItemDescriptionManager description = FindObjectOfType<ItemDescriptionManager>();
            if (description != null) {
                description.updateDescription(chosenItem.description);
            }
        }
    }
}
