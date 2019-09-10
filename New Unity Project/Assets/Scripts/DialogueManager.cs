using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    public TMP_Text dialogueText;
    public MonoBehaviour firstPersonController;

    float timeLeft = 5f;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            Debug.Log("In Here.");
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Cursor.lockState = CursorLockMode.None;
        //fpsEnable = firstPersonController.GetComponent(typeof(ScriptableObject));
        Debug.Log("Staring conversation with: " + dialogue.name);

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        firstPersonController.enabled = false;
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialog()
    {
        Debug.Log("Ending");
        firstPersonController.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
