using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Zenject;

public class PlayerWin : MonoBehaviour
{
    public GameObject winUI;

    private bool winUIState;
    [Inject] private EditorPlayScreensHandler editorPlayScreensHandler;

    void Awake()
    {
        winUIState = false;
        winUI.SetActive(winUIState);
    }

    public void Pause()
    {
        winUIState = !winUIState;
        Time.timeScale = winUIState ? 0f : 1f;
        winUI.gameObject.SetActive(winUIState);
        GetComponent<CarController>().enabled = !winUIState;
    }

    public void GoToEditor()
    {
        Pause();
        editorPlayScreensHandler.SwitchToEditor();
    }

    public void RestartGame()
    {
        Pause();
        editorPlayScreensHandler.RestartPlay();
    }

    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
