using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpObject : MonoBehaviour
{
    [SerializeField]
    private Image UIImage;

    [SerializeField]
    private Image FlashbackImage;

    bool BrokenPhone = true;

    // Update is called once per frame
    void Update()
    {
        if (FlashbackImage == enabled)
        {
            //UIImage.enabled = false;
        }
        else
        {
            //UIImage.enabled = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FlashbackPhone"))
        {
            this.gameObject.SetActive(false);
            UIImage.enabled = true;
            BrokenPhone = true;
        }
    }
}
