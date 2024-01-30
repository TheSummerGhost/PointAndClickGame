using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Describe : MonoBehaviour
{
    // Start is called before the first frame update
    public string description;
    

    void Start()
    {

    }

    // Update is called once per frame
    void OnMouseOver()
    {
        {
            if (Input.GetMouseButtonDown(1))
            {
                // Debug.Log(description);
                PopUpTextBox message = FindObjectOfType<PopUpTextBox>();
                if (message != null) {
                    message.displayMessage(description);
                }
            }
        }
    }
}
