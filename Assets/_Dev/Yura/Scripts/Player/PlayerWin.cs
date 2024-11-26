using UnityEngine;
using Zenject;

/// <summary>
/// Player win's UI
/// </summary>
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

    /// <summary>
    /// Turning on the win's UI
    /// </summary>
    public void Pause()
    {
        winUIState = !winUIState;
        Time.timeScale = winUIState ? 0f : 1f;
        winUI.gameObject.SetActive(winUIState);
        GetComponent<CarController>().enabled = !winUIState;
    }

    /// <summary>
    /// The event on click Editor
    /// </summary>
    public void GoToEditor()
    {
        Pause();
        editorPlayScreensHandler.SwitchToEditor();
    }

    /// <summary>
    /// The event on click Restart
    /// </summary>
    public void RestartGame()
    {
        Pause();
        editorPlayScreensHandler.RestartPlay();
    }

    /// <summary>
    /// The event on click Quit
    /// </summary>
    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
