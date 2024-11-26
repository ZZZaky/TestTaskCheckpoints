using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Toggler for menus in editor
/// </summary>
public class ToggleMenuHandler : MonoBehaviour
{
    public Toggle toggleButton;
    public Image dropdownArrowClosed;
    public Image dropdownArrowOpened;
    public GameObject save;
    public GameObject load;
    public GameObject reset;

    private SaveMap saveButton;
    private LoadMap loadButton;
    private ResetMap resetButton;

    void Start()
    {
        saveButton = save.GetComponent<SaveMap>();
        loadButton = load.GetComponent<LoadMap>();
        resetButton = reset.GetComponent<ResetMap>();
        ToggleMenu();
    }

    /// <summary>
    /// The event for toggling all menu's subobjects
    /// </summary>
    public void ToggleMenu()
    {
        save.SetActive(toggleButton.isOn);
        load.SetActive(toggleButton.isOn);
        reset.SetActive(toggleButton.isOn);

        if(toggleButton.isOn)
        {
            dropdownArrowClosed.enabled = false;
            dropdownArrowOpened.enabled = true;
        }
        else
        {
            dropdownArrowClosed.enabled = true;
            dropdownArrowOpened.enabled = false;
        }
        saveButton.CloseUI();
        loadButton.CloseUI();
    }

    /// <summary>
    /// The event on click Save
    /// </summary>
    public void OnClickSave()
    {
        loadButton.CloseUI();
        saveButton.OnClickSave();
    }

    /// <summary>
    /// The event on click Load
    /// </summary>
    public void OnClickLoad()
    {
        saveButton.CloseUI();
        loadButton.OnClickLoad();
    }

    /// <summary>
    /// The event on click Reset
    /// </summary>
    public void OnClickReset()
    {
        saveButton.CloseUI();
        loadButton.CloseUI();
        resetButton.ResetCheckpoints();
    }
}
