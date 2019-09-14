using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifePickUp : MonoBehaviour
{
    [SerializeField]
    public GameObject knife;

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
                    Destroy(knife.gameObject);
                }
            }
        }
    }
}
