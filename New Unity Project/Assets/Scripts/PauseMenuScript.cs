using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField]
    public GameObject pauseMenu;
    [SerializeField]
    public GameObject button;
    [SerializeField]
    public GameObject buttonTwo;
    // Start is called before the first frame update
    void Start()
    {
        //pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("PauseMenu");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            pauseMenu.SetActive(true);
            button.SetActive(true);
            buttonTwo.SetActive(true);
        }
    }

    public void ReturnToGame()
    {
        pauseMenu.SetActive(false);
        button.SetActive(false);
        buttonTwo.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitGame()
    {
        Debug.Log("Quiting from pause menu.");
        Application.Quit();
    }
}
