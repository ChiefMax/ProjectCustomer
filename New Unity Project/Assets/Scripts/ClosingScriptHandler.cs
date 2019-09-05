using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosingScriptHandler : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
