using UnityEngine;
using Zenject;

/// <summary>
/// Player menu's UI
/// </summary>
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

    /// <summary>
    /// Turning on the menu's UI
    /// </summary>
    public void Pause()
    {
        menuState = !menuState;
        Time.timeScale = menuState ? 0f : 1f;
        menuUI.gameObject.SetActive(menuState);
        GetComponent<CarController>().enabled = !menuState;
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
    /// The event on click Quit
    /// </summary>
    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
