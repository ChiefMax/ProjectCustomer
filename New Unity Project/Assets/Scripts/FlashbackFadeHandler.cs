using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashbackFadeHandler : MonoBehaviour
{
    public CanvasGroup UIElement;
    [SerializeField]
    private RawImage UIImage;
    bool fadeinStarted = false;

    void OnEnabled()
    {
        FadeIn();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (fadeinStarted == false)
        {
            FadeIn();
            fadeinStarted = true;
        }
        else
        {
            FadeOut();
        }*/
    }

    public void FadeIn()
    {
        StartCoroutine(FadeElement(UIElement, UIElement.alpha, 1));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeElement(UIElement, UIElement.alpha, 0));
    }

    public IEnumerator FadeElement(CanvasGroup ca, float start, float end, float lerpTime = 0.5f)
    {
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while (true)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);


            UIElement.alpha = currentValue;

            if (percentageComplete >= 1)
            {
                break;
            }

            yield return new WaitForEndOfFrame();
        }

        Debug.Log("This is done.");
    }
}
