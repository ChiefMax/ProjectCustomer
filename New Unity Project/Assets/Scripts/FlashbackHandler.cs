using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashbackHandler : MonoBehaviour
{
    [SerializeField]
    private Sprite[] flashbacks;
    [SerializeField]
    private Image UIImage;

    [SerializeField]
    private GameObject knife;

    [SerializeField]
    private GameObject person;

    [SerializeField]
    public MonoBehaviour firstPersonController;

    [SerializeField]
    private Animator anim;

    public AudioClip FlashbackSound;

    public AudioSource source;

    SpriteRenderer rend;

    float timeLeft = 3f;
    float endFlashback = 5f;

    bool once = false;
    bool onceSound = false;
    bool resetUIFlashback = false;

    bool PartyFlashback = false;
    bool PhoneFlashback = false;
    bool BottleFlashback = false;
    bool BeerCanFlashback = false;
    bool KnifeFlashback = false;
    bool PersonFlashback = false;

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
        if (PhoneFlashback || PartyFlashback || BottleFlashback || BeerCanFlashback || KnifeFlashback || PersonFlashback)
        {
            timeLeft -= Time.deltaTime;
        }

        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                //BoxCollider bc = hit.collider as BoxCollider;
                if (hit.transform.gameObject == knife)
                {
                    Debug.Log("KNIFE!");
                    //Destroy(knife.gameObject);
                    //knife.gameObject.SetActive(false);
                    KnifeFlashback = true;
                    onceSound = true;
                }

                if (hit.transform.gameObject == person)
                {
                    Debug.Log("PERSON!");
                    //Destroy(knife.gameObject);
                    //knife.gameObject.SetActive(false);
                    PersonFlashback = true;
                    onceSound = true;
                }
            }
        }

        if (PhoneFlashback)
        {
            Debug.Log("Phone flashback");
            firstPersonController.enabled = false;
            UIImage.enabled = true;
            UIImage.sprite = flashbacks[0];
            StartCoroutine(Fading());

            if (onceSound)
            {
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
            Debug.Log("Party flashback");
            firstPersonController.enabled = false;
            UIImage.enabled = true;
            UIImage.sprite = flashbacks[1];
            StartCoroutine(Fading());

            if (onceSound)
            {
                source.Play();
                onceSound = false;
            }
            endFlashback -= Time.deltaTime;
            if (endFlashback < 0)
            {
                ResetFlashback();
            }
        }

        if (BottleFlashback)
        {
            Debug.Log("Bottle flashback");
            firstPersonController.enabled = false;
            UIImage.enabled = true;
            UIImage.sprite = flashbacks[2];
            StartCoroutine(Fading());

            if (onceSound)
            {
                source.Play();
                onceSound = false;
            }
            endFlashback -= Time.deltaTime;
            if (endFlashback < 0)
            {
                Debug.Log("Ready to reset.");
                ResetFlashback();
            }
        }

        if (BeerCanFlashback)
        {
            Debug.Log("Beer can flashback");
            firstPersonController.enabled = false;
            UIImage.enabled = true;
            UIImage.sprite = flashbacks[3];
            StartCoroutine(Fading());

            if (onceSound)
            {
                source.Play();
                onceSound = false;
            }
            endFlashback -= Time.deltaTime;
            if (endFlashback < 0)
            {
                ResetFlashback();
            }
        }

        if (KnifeFlashback)
        {
            Debug.Log("Knife flashback");
            firstPersonController.enabled = false;
            UIImage.enabled = true;
            UIImage.sprite = flashbacks[4];
            StartCoroutine(Fading());

            if (onceSound)
            {
                source.Play();
                onceSound = false;
            }
            endFlashback -= Time.deltaTime;
            if (endFlashback < 0)
            {
                ResetFlashback();
            }
        }

        if (PersonFlashback)
        {
            Debug.Log("Person flashback");
            firstPersonController.enabled = false;
            UIImage.enabled = true;
            UIImage.sprite = flashbacks[5];
            StartCoroutine(Fading());

            if (onceSound)
            {
                source.Play();
                onceSound = false;
            }
            endFlashback -= Time.deltaTime;
            if (endFlashback < 0)
            {
                ResetFlashback();
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FlashbackPhone"))
        {
            UIImage.enabled = true;
            PhoneFlashback = true;
            other.enabled = false;
            onceSound = true;
        }

        //Sneaky actually the beer cans.
        if (other.CompareTag("FlashbackParty"))
        {
            PartyFlashback = true;
            UIImage.enabled = true;
            other.enabled = false;
            onceSound = true;
        }

        if (other.CompareTag("BottleFlashback"))
        {
            BottleFlashback = true;
            UIImage.enabled = true;
            other.enabled = false;
            onceSound = true;
        }
    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => UIImage.color.a == 1);
    }

    void ResetFlashback()
    {
        Debug.Log("Resetting.");
        UIImage.enabled = false;
        PhoneFlashback = false;
        PartyFlashback = false;
        BottleFlashback = false;
        KnifeFlashback = false;
        PersonFlashback = false;
        UIImage.enabled = false;
        timeLeft = 3f;
        endFlashback = 5f;
        once = false;
        onceSound = false;
        firstPersonController.enabled = true;
        source.Stop();
    }
}
