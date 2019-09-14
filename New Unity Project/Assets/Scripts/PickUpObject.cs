using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpObject : MonoBehaviour
{
    [SerializeField]
    private Image UIImage;

    bool BrokenPhone = true;

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButton(0)) {
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        BoxCollider bc = hit.collider as BoxCollider;
        //        if (bc != null)
        //        {
        //            //Destroy(phoneBroken.gameObject);
        //            phoneBroken.SetActive(false);
        //            brokenPhone = true;
        //        }
        //    }
        //}

        //if (Input.GetMouseButton(0))
        //{
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        BoxCollider bc = hit.collider as BoxCollider;
        //        if (bc != null && brokenPhone)
        //        {
        //            //Destroy(phoneWorking.gameObject);
        //            phoneWorking.SetActive(false);
        //        }
        //    }
        //}
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            UIImage.enabled = true;
            BrokenPhone = true;
        }
    }
}
