using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public void OnClickSave()
    {
        loadButton.CloseUI();
        saveButton.OnClickSave();
    }

    public void OnClickLoad()
    {
        saveButton.CloseUI();
        loadButton.OnClickLoad();
    }

    public void OnClickReset()
    {
        saveButton.CloseUI();
        loadButton.CloseUI();
        resetButton.ResetCheckpoints();
    }
}
