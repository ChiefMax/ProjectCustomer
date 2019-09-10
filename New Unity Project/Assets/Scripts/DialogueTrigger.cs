using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void TriggerTest()
    {
        Debug.Log("Testing the button.");
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Test Dialog.");
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
