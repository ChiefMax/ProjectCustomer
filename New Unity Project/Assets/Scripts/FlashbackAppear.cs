using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashbackAppear : MonoBehaviour
{
    [SerializeField]
    private Sprite[] flashbacks;
    [SerializeField]
    private Image UIImage;

    SpriteRenderer rend;

    float timeLeft = 3f;
    float endFlashback = 5f;

    bool PartyFlashback = false;
    bool PhoneFlashback = false;

    bool resetUIFlashback = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FlashbackPhone"))
        {
            Debug.Log("PhoneFlashback");
            UIImage.enabled = true;
            PhoneFlashback = true;

        }

        if (other.CompareTag("FlashbackParty"))
        {
            Debug.Log("PartyFlashback");
            UIImage.enabled = true;
            PartyFlashback = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        Color c = rend.material.color;
        c.a = 0f;
        rend.material.color = c;
    }

    // Update is called once per frame
    void Update()
    {
        if (PhoneFlashback || PartyFlashback)
        {
            timeLeft -= Time.deltaTime;
        }
        if (/*timeLeft < 0 &&*/ PhoneFlashback)
        {
            Debug.Log("UI Appearing Phone");
            UIImage.sprite = flashbacks[1];

            endFlashback -= Time.deltaTime;
            if (endFlashback < 0)
            {
                ResetFlashback();
            }
        }

        if (/*timeLeft < 0 &&*/ PartyFlashback)
        {
            Debug.Log("UI Appearing Party");
            UIImage.sprite = flashbacks[2];
            endFlashback -= Time.deltaTime;
            if (endFlashback < 0)
            {
                ResetFlashback();
            }
        }
    }

    void ResetFlashback()
    {
        Debug.Log("Resetting.");
        UIImage.enabled = false;
        PhoneFlashback = false;
        PartyFlashback = false;
        UIImage.enabled = false;
        timeLeft = 3f;
        endFlashback = 3f;
        UIImage.sprite = flashbacks[0];
        FadeOut();
    }

    public void StartFading()
    {
        StartCoroutine(FadeIn());
    }

    public void FadingOut()
    {
        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeIn()
    {
        for(float f = 0.05f; f <= 1; f += 0.5f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator FadeOut()
    {
        for (float f = 1f; f >= -0.05f; f -= 0.5f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForEndOfFrame();
        }
    }
}
