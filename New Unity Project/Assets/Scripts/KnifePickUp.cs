using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifePickUp : MonoBehaviour
{
    [SerializeField]
    public GameObject knife;

    bool PickedUp = false;

    [SerializeField]
    private Sprite flashbacks;
    [SerializeField]
    private Image UIImage;

    [SerializeField]
    private Animator anim;

    public AudioClip FlashbackSound;

    public AudioSource source;

    SpriteRenderer rend;

    float timeLeft = 3f;
    float endFlashback = 5f;
    float fadeTimer = 2.5f;

    bool once = false;
    bool resetUIFlashback = false;

    void Start()
    {
        source.clip = FlashbackSound;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                BoxCollider bc = hit.collider as BoxCollider;
                if (bc != null)
                {
                    //Destroy(knife.gameObject);
                    knife.gameObject.SetActive(false);
                    PickedUp = true;
                    once = true;
                }
            }
        }

        if (PickedUp)
        {
            UIImage.enabled = true;
            UIImage.sprite = flashbacks;
            StartCoroutine(Fading());
            if (once)
            {
                source.Play();
                once = false;
            }
            endFlashback -= Time.deltaTime;
            if (endFlashback < 0)
            {
                ResetFlashback();
            }
        }
    }

    void ResetFlashback()
    {
        //Debug.Log("Resetting.");
        UIImage.enabled = false;
        timeLeft = 3f;
        endFlashback = 3f;
        PickedUp = false;
        once = false;
        source.Stop();
        knife.SetActive(false);
    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => UIImage.color.a == 1);
    }
}
