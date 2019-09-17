using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForFlashBackScript : MonoBehaviour
{
    [SerializeField]
    public MonoBehaviour VOstart;

    bool MouseOver = false;
    bool once = false;
    float timer = 6f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MouseOver)
        {
            timer -= Time.deltaTime;
        }

        if (!once)
        {
            if (timer <= 0) {
                VOstart.enabled = true;
                once = true;
            }
        }
    }

    void OnMouseOver()
    {
        print("Over object");
        
    }
}
