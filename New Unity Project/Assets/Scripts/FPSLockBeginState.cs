using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLockBeginState : MonoBehaviour
{
    [SerializeField]
    public MonoBehaviour firstPersonController;

    float lockTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        firstPersonController.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        lockTime -= Time.deltaTime;

        if (lockTime <= 0)
        {
            firstPersonController.enabled = true;
        }
    }
}
