using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerMenu : MonoBehaviour
{
    private GameObject menuUI;
    private bool menuState;
    [Inject] private PlayerHandler playerHandler;
    [Inject] private EditorPlayScreensHandler editorPlayScreensHandler;

    void Awake()
    {
        menuUI = GetComponentInChildren<Canvas>().gameObject;
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
        playerHandler.GetComponent<PlayerMovement>().enabled = !menuState;
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
