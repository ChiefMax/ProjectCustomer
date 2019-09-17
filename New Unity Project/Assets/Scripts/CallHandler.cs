using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CallHandler : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textHelp;

    public AudioClip DialUpSound;
    public AudioSource source;

    bool playerEnter = false;
    bool playOnce = false;
    bool keyPressedB = false;

    float timeLeft = 5f;

    // Start is called before the first frame update
    void Start()
    {
        source.clip = DialUpSound;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerEnter)
        {
            textHelp.enabled = true;
        }
        if (playerEnter && Input.GetKeyDown(KeyCode.C))
        {
            keyPressedB = true;
            
            if (playOnce)
            {
                playOnce = false;
                source.Play();
            }
        }
        if (keyPressedB)
        {
            timeLeft -= Time.deltaTime;
        }
        if (timeLeft < 0)
        {
            Debug.Log("NEEEEEEEEEEEEXT!");
            SceneManager.LoadScene("TitleScreen");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerEnter = true;
            playOnce = true;
        }
    }
}
