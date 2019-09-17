using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpObject : MonoBehaviour
{
    [SerializeField]
    private Image PhoneImage;

    [SerializeField]
    private Sprite[] phones;

    //[SerializeField]
    //private Image FlashbackImage;

    [SerializeField]
    private GameObject phoneBroken;

    [SerializeField]
    private GameObject workingPhone;

    float timer = 5f;

    bool BrokenPhone = false;
    bool WorkingPhone = false;
    bool StartTimer = false;

    // Update is called once per frame
    void Update()
    {
        if (StartTimer)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                PhoneImage.enabled = true;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == phoneBroken)
                {
                    Debug.Log("Broken phone");
                    StartTimer = true;
                    BrokenPhone = true;
                    phoneBroken.SetActive(false);
                }

                if (hit.transform.gameObject == workingPhone)
                {
                    Debug.Log("Working phone");
                    StartTimer = true;
                    workingPhone.SetActive(false);
                    BrokenPhone = false;
                    WorkingPhone = true;
                }
            }
        }

        if (BrokenPhone)
        {
            StartTimer = false;
            PhoneImage.sprite = phones[0];
        }

        if (WorkingPhone)
        {
            //PhoneImage.enabled = true;
            StartTimer = false;
            PhoneImage.sprite = phones[1];
        }

        //if (FlashbackImage == enabled)
        //{
        //    UIImage.enabled = false;
        //}
        //else
        //{
        //    UIImage.enabled = true;
        //}
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("FlashbackPhone"))
    //    {
    //        //this.gameObject.SetActive(false);
    //        UIImage.enabled = true;
    //        BrokenPhone = true;
    //    }
    //}
}
