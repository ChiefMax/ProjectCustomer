using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDialogueHandler : MonoBehaviour
{
    public AudioClip[] DialogueSound;
    public AudioSource source;

    //bool StillDialogueLeft = false;
    //bool canPlayNextLine = false;
    //bool AllDone = false;
    //float Timer = 0f;
    //int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playEngineSound(DialogueSound));
    }

    IEnumerator playEngineSound(AudioClip[] playThis)
    {
        for (int i = 0; i < DialogueSound.Length; i++)
        {
            source.PlayOneShot(playThis[i]);
            yield return new WaitForSeconds(playThis[i].length);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
