using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDescriptionManager : MonoBehaviour
{

    public TMPro.TextMeshProUGUI descriptionToDisplay;

    public Fade fade;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void updateDescription(string description) {
        StopAllCoroutines();
        descriptionToDisplay.text = description;
        fade.Show();
        StartCoroutine(hideMessage());
    }

    public IEnumerator hideMessage() {
        yield return new WaitForSeconds(3.5f);
        fade.Hide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
