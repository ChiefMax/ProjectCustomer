using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashbackAppear : MonoBehaviour
{
    [SerializeField]
    private Sprite flashbacks;
    [SerializeField]
    private Image UIImage;

    [SerializeField]
    public MonoBehaviour firstPersonController;

    [SerializeField]
    private Animator anim;

    public AudioClip FlashbackSound;

    public AudioSource source;

    SpriteRenderer rend;

    float timeLeft = 3f;
    float endFlashback = 3f;
    //float fadeTimer = 2.5f;

    bool PartyFlashback = false;
    bool PhoneFlashback = false;

    bool once = false;
    bool onceSound = false;
    bool resetUIFlashback = false;
    bool fadeOut = false;

    void OnTriggerEnter(Collider other)
    {
        if (/*other.CompareTag("FlashbackPhone")*/other.CompareTag("Player") && once == false)
        {
            Debug.Log("PhoneFlashback");
            StartCoroutine(Fading());
            UIImage.enabled = true;
            PhoneFlashback = true;
            once = true;
            onceSound = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        Color c = rend.material.color;
        c.a = 0f;
        rend.material.color = c;

        source.clip = FlashbackSound;
    }

    // Update is called once per frame
    void Update()
    {
        if (PhoneFlashback || PartyFlashback)
        {
            timeLeft -= Time.deltaTime;
        }
        if (PhoneFlashback)
        {
            Debug.Log("UI Appearing Phone");
            firstPersonController.enabled = false;
            UIImage.sprite = flashbacks;

            if (onceSound) {
                source.Play();
                onceSound = false;
            }
            endFlashback -= Time.deltaTime;
            if (endFlashback < 0)
            {
                ResetFlashback();
            }
        }

        if (PartyFlashback)
        {
            Debug.Log("UI Appearing Party");
            UIImage.sprite = flashbacks;
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
        once = false;
        firstPersonController.enabled = true;
        source.Stop();
    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => UIImage.color.a == 1);
    }

    //public void StartFading()
    //{
    //    StartCoroutine(FadeIn());
    //}

    //public void FadingOut()
    //{
    //    StartCoroutine(FadeOut());
    //}

    //public IEnumerator FadeIn()
    //{
    //    for(float f = 0.05f; f <= 1; f += 0.5f)
    //    {
    //        Color c = rend.material.color;
    //        c.a = f;
    //        rend.material.color = c;
    //        yield return new WaitForEndOfFrame();
    //    }
    //}

    //public IEnumerator FadeOut()
    //{
    //    for (float f = 1f; f >= -0.05f; f -= 0.5f)
    //    {
    //        Color c = rend.material.color;
    //        c.a = f;
    //        rend.material.color = c;
    //        yield return new WaitForEndOfFrame();
    //    }
    //}
}
