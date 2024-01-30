using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class PopUpTextBox : MonoBehaviour
{
    public GameObject textBox; 
    public TMP_Text text; 
    public Button continueButton; 
    public string message; 
    public float delay = 0.01f; 
    public float popUpDuration = 0.5f;
    private bool isWriting = false;

    void Start()
    {
        // int lines = text.textInfo.lineCount;


        textBox.SetActive(false);


        continueButton.onClick.AddListener(Dismiss);
    }



    public void displayMessage(string messageToDisplay) {
        if (isWriting) 
        {
            return;
        }
        message = messageToDisplay;
        StartCoroutine(PopUp());
        
    }

    IEnumerator PopUp()
    {
        continueButton.interactable = false;
        isWriting = true;

        yield return new WaitForSeconds(popUpDuration);


        textBox.SetActive(true);


        foreach (char c in message)
        {
            text.text += c;
            yield return new WaitForSeconds(delay);
        }


        continueButton.interactable = true;
        
    }

    void Dismiss()
    {
        textBox.SetActive(false);

        text.text = "";
        isWriting = false;
        continueButton.interactable = false;
    }
}
