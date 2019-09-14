using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickFlashbackAppear : MonoBehaviour
{
    [SerializeField]
    private Sprite flashbacks;
    [SerializeField]
    private Image UIImage;

    [SerializeField]
    private Animator anim;

    SpriteRenderer rend;

    public AudioClip FlashbackSound;

    public AudioSource source;

    float timeLeft = 3f;
    float endFlashback = 5f;
    float fadeTimer = 2.5f;

    bool once = false;
    bool resetUIFlashback = false;
    bool fadeOut = false;

    // Start is called before the first frame update
    void Start()
    {
        source.clip = FlashbackSound;
    }

    // Update is called once per frame
    void Update()
    {
        UIImage.sprite = flashbacks;
        endFlashback -= Time.deltaTime;
        if (endFlashback < 0)
        {
            ResetFlashback();
        }
    }

    void ResetFlashback()
    {
        Debug.Log("Resetting.");
        UIImage.enabled = false;
        UIImage.enabled = false;
        timeLeft = 3f;
        endFlashback = 3f;
        once = false;
        source.Stop();
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
        if (Input.GetMouseButtonDown(0)){
            StartCoroutine(Fading());
            UIImage.enabled = true;
            source.Play();
        }
    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => UIImage.color.a == 1);
    }
}
