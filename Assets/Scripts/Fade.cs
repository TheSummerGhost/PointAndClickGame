using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class Fade : MonoBehaviour
{
    public float fadeTime = 0.25f;
    private CanvasGroup TheCanvas;

    public bool showing = false;
    public bool ShowOnStart = false;

    void OnEnable()
    {
        TheCanvas = GetComponent<CanvasGroup>();
    }

    private void Awake() {
        if (ShowOnStart == false) {
            TheCanvas = GetComponent<CanvasGroup>();
            ForceOff();
        } else {
            showing = true;
        }
    }

    public void ForceOn() {
        gameObject.SetActive(true);
        TheCanvas.alpha = 1;
        showing = true;
        StopAllCoroutines();
    }

    public void ForceOff() {
        gameObject.SetActive(false);
        TheCanvas.alpha = 0;
        showing = false;
        StopAllCoroutines();
    }

    public void Toggle() {
        if(showing) {
            Hide();
        } else {
            Show();
        }
    }

    public void Show()
    {
        if (!showing)
        {
            
            gameObject.SetActive(true);
            StopAllCoroutines();

            showing = true;
            StartCoroutine(FadeTimeManager(1));
        }
    }

    public void Hide()
    {
        if (showing)
        {
            if (gameObject.activeSelf == false)
            {
                return;
            }
            StopAllCoroutines();

            showing = false;
            StartCoroutine(FadeTimeManager(0));
        }
    }

    public IEnumerator FadeTimeManager(float end)
    {

        float Start = TheCanvas.alpha;
        float End = end;

        for (float t = 0f; t < fadeTime; t += Time.deltaTime)
        {
            
            float normalizedTime = t / fadeTime;
            TheCanvas.alpha = Mathf.Lerp(Start, End, normalizedTime);
            yield return null;
        }

        TheCanvas.alpha = end;

    }
}
