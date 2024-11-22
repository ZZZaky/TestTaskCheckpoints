using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMenuHandler : MonoBehaviour
{
    public Toggle toggleButton;
    public Image dropdownArrowClosed;
    public Image dropdownArrowOpened;
    public List<GameObject> menuButtons;

    void Start()
    {
        ToggleMenu();
    }

    public void ToggleMenu()
    {
        for (int i = 0; i < menuButtons.Count; i++)
        {
            menuButtons[i].SetActive(toggleButton.isOn);
        }

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
    }
}
