using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonStartVO : MonoBehaviour
{
    [SerializeField]
    public MonoBehaviour VOstart;
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
        print("Over object");
        VOstart.enabled = true;
    }

    //void OnMouseExit()
    //{
    //    VOstart.enabled = false;
    //}
}
