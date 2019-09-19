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
    private Image PhoneImage;

    [SerializeField]
    private Sprite[] phones;

    [SerializeField]
    private GameObject knife;

    [SerializeField]
    private GameObject person;
    [SerializeField]
    private GameObject party;
    [SerializeField]
    private GameObject bottle;
    //[SerializeField]
    //private GameObject beerCan;
    [SerializeField]
    private GameObject StuckInCar;
    [SerializeField]
    private GameObject BrokenPhone;
    [SerializeField]
    private GameObject WorkingPhone;
    [SerializeField]
    private GameObject WorkingPhoneObject;
    [SerializeField]
    private GameObject KnifeObject;

    [SerializeField]
    public MonoBehaviour firstPersonController;

    [SerializeField]
    private Animator anim;

    public AudioClip FlashbackSound;

    public AudioSource source;

    SpriteRenderer rend;

    float timeLeft = 3f;
    float endFlashback = 4f;
    float wait = 5f;
    float DisablePhone = 5f;

    bool once = false;
    bool onceSound = false;
    bool resetUIFlashback = false;
    bool TimerStartPhone = false;

    bool PartyFlashback = false;
    bool PhoneFlashback = false;
    bool BottleFlashback = false;
    bool BeerCanFlashback = false;
    bool KnifeFlashback = false;
    bool PersonFlashback = false;
    bool workingPhoneEnd = false;
    bool BrokenPhoneBool = false;
    bool WorkingPhoneBool = false;

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
                if (hit.transform.gameObject == knife)
                {
                    KnifeFlashback = true;
                    onceSound = true;
                    knife.SetActive(false);
                    KnifeObject.SetActive(false);
                    StuckInCar.SetActive(false);
                }

                if (hit.transform.gameObject == person)
                {
                    PersonFlashback = true;
                    onceSound = true;
                }

                if (hit.transform.gameObject == party)
                {
                    Debug.Log("Bottle");
                    PartyFlashback = true;
                    onceSound = true;
                }

                //if (hit.transform.gameObject == beerCan)
                //{
                //    BeerCanFlashback = true;
                //    onceSound = true;
                //}

                if (hit.transform.gameObject == bottle)
                {
                    Debug.Log("Bottle");
                    BottleFlashback = true;
                    onceSound = true;
                }

                if (hit.transform.gameObject == BrokenPhone)
                {
                    //BrokenPhoneBool = true;
                    print("working phone.");
                    BrokenPhone.SetActive(false);
                    PhoneFlashback = true;
                    onceSound = true;
                }

                if (hit.transform.gameObject == WorkingPhone)
                {
                    print("working phone.");
                    workingPhoneEnd = true;
                    onceSound = true;
                    WorkingPhoneObject.SetActive(false);
                    BrokenPhoneBool = false;
                    //WorkingPhoneBool = true;
                }
            }
        }

        if (PhoneFlashback)
        {
            //Debug.Log("Phone flashback");
            firstPersonController.enabled = false;
            UIImage.enabled = true;
            UIImage.sprite = flashbacks[0];
            anim.enabled = true;
            PhoneImage.enabled = true;
            PhoneImage.sprite = phones[0];
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
                TimerStartPhone = true;
            }
        }

        if (TimerStartPhone)
        {
            DisablePhone -= Time.deltaTime;

            if (DisablePhone <= 0)
            {
                PhoneImage.enabled = false;
            }
        }

        if (PartyFlashback)
        {
            //Debug.Log("Party flashback");
            firstPersonController.enabled = false;
            UIImage.enabled = true;
            UIImage.sprite = flashbacks[1];
            anim.enabled = true;
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
            //Debug.Log("Bottle flashback");
            firstPersonController.enabled = false;
            UIImage.enabled = true;
            UIImage.sprite = flashbacks[2];
            anim.enabled = true;
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
            //Debug.Log("Beer can flashback");
            firstPersonController.enabled = false;
            UIImage.enabled = true;
            UIImage.sprite = flashbacks[3];
            anim.enabled = true;
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
            //Debug.Log("Knife flashback");
            firstPersonController.enabled = false;
            UIImage.enabled = true;
            UIImage.sprite = flashbacks[4];
            anim.enabled = true;
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
            //Debug.Log("Person flashback");
            firstPersonController.enabled = false;
            UIImage.enabled = true;
            UIImage.sprite = flashbacks[5];
            anim.enabled = true;
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

        if (workingPhoneEnd)
        {
            PhoneImage.enabled = true;
            PhoneImage.sprite = phones[1];
        }

    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("FlashbackPhone"))
    //    {
    //        UIImage.enabled = true;
    //        PhoneFlashback = true;
    //        other.enabled = false;
    //        onceSound = true;
    //    }

    //    //Sneaky actually the beer cans.
    //    if (other.CompareTag("FlashbackParty"))
    //    {
    //        PartyFlashback = true;
    //        UIImage.enabled = true;
    //        other.enabled = false;
    //        onceSound = true;
    //    }

    //    if (other.CompareTag("BottleFlashback"))
    //    {
    //        BottleFlashback = true;
    //        UIImage.enabled = true;
    //        other.enabled = false;
    //        onceSound = true;
    //    }
    //}

    IEnumerator Fading()
    {
        //anim.SetBool("Fade", true);
        yield return new WaitUntil(() => UIImage.color.a == 1);
       //anim.SetBool("Fade", false);
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
        endFlashback = 4f;
        once = false;
        onceSound = false;
        firstPersonController.enabled = true;
        source.Stop();
        anim.SetBool("Fade", false);
        anim.enabled = false;
    }
}
