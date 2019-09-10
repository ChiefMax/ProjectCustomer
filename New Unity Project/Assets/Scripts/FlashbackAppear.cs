using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashbackAppear : MonoBehaviour
{
    [SerializeField]
    private Material[] flashbacks;
    [SerializeField]
    private RawImage UIImage;
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

    void OnTriggerExit(Collider other)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PhoneFlashback || PartyFlashback)
        {
            timeLeft -= Time.deltaTime;
        }
        if (timeLeft < 0 && PhoneFlashback)
        {
            Debug.Log("UI Appearing Phone");
            UIImage.material = flashbacks[1];
            endFlashback -= Time.deltaTime;
            if (endFlashback < 0)
            {
                ResetFlashback();
            }
        }

        if (timeLeft < 0 && PartyFlashback)
        {
            Debug.Log("UI Appearing Party");
            UIImage.material = flashbacks[2];
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
        UIImage.material = flashbacks[0];
    }
}
