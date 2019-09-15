using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowHandler : MonoBehaviour
{
    [SerializeField]
    private Behaviour halo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        halo.enabled = true;
    }

    void OnMouseExit()
    {
        halo.enabled = false;
    }
}
