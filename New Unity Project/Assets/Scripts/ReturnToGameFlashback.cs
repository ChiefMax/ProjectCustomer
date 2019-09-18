using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToGameFlashback : MonoBehaviour
{
    float wait = 5f;

    string LevelToLoad = "";
    bool TimerFade = false;
    //[SerializeField]
    //private Animator fadeAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FadeToLevel();
    }

    public void FadeToLevel()
    {
        TimerFade = true;
        if (TimerFade)
        {
            //fadeAnim.enabled = true;
            wait -= Time.deltaTime;
            if (wait <= 0)
            {
                SceneManager.LoadScene("NewCrashedCar");
                TimerFade = false;
                wait = 5f;
            }
        }
    }
}
