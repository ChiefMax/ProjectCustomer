using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGameHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject knife;
    [SerializeField]
    private GameObject person;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private Animator anim2;

    bool PartyEnd = false;
    bool PhoneEnd = false;
    bool BottleEnd = false;
    bool BeerEnd = false;
    bool KnifeEnd = false;
    bool PersonEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
                //BoxCollider bc = hit.collider as BoxCollider;
                if (hit.transform.gameObject == knife)
                {
                    print("knife end.");
                    KnifeEnd = true;
                }

                if (hit.transform.gameObject == person)
                {
                    print("person end.");
                    PersonEnd = true;
                }
            }
        }

        if (PartyEnd && PhoneEnd && BottleEnd && /*BeerEnd &&*/ /*KnifeEnd &&*/ PersonEnd || Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("End game starting.");
            //anim.SetBool("Flicker", true);
            anim.enabled = true;
            anim2.enabled = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FlashbackPhone"))
        {
            print("Phone end.");
            PhoneEnd = true;
        }

        //Sneaky actually the beer cans.
        if (other.CompareTag("FlashbackParty"))
        {
            print("Party end.");
            PartyEnd = true;
        }

        if (other.CompareTag("BottleFlashback"))
        {
            print("Bottle end.");
            BottleEnd = true;
        }
    }
}
