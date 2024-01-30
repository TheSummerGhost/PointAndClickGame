using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VibrateOnHover : MonoBehaviour
{
    private Vector3 originalPosition;

    private IEnumerator vibrateCouroutine;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual IEnumerator Vibrate() {
        do {
            Vector3 updatedPosition = originalPosition;
            updatedPosition.x += Random.Range(-0.02f, 0.02f);
            updatedPosition.y += Random.Range(-0.02f, 0.02f);
            transform.position = updatedPosition;
            yield return new WaitForSeconds(0.05f);
        } 
        while (true);
    } 

    void OnMouseEnter()
    {   
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        vibrateCouroutine = Vibrate();
        StartCoroutine(vibrateCouroutine);
    }

    void OnMouseExit()
    {
        if (vibrateCouroutine != null)
        {
            StopCoroutine(vibrateCouroutine);
            vibrateCouroutine = null;
        }
    }
}
