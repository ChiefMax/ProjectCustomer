using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDialogueHandler : MonoBehaviour
{
    public AudioClip[] DialogueSound;
    public AudioSource source;

    bool StillDialogueLeft = false;
    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        source.clip = DialogueSound[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying && !StillDialogueLeft)
        {
            foreach (var element in DialogueSound)
            {
                counter++;
                source.PlayOneShot(element);
                if (counter >= DialogueSound.Length)
                {
                    StillDialogueLeft = true;
                }                
            }
        }
    }
}
