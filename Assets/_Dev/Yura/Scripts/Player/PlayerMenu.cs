using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerMenu : MonoBehaviour
{
    public GameObject menuUI;

    private bool menuState;
    [Inject] private EditorPlayScreensHandler editorPlayScreensHandler;

    void Awake()
    {
        menuState = false;
        menuUI.SetActive(menuState);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        menuState = !menuState;
        Time.timeScale = menuState ? 0f : 1f;
        menuUI.gameObject.SetActive(menuState);
        GetComponent<CarController>().enabled = !menuState;
    }

    public void GoToEditor()
    {
        Pause();
        editorPlayScreensHandler.SwitchToEditor();
    }

    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
