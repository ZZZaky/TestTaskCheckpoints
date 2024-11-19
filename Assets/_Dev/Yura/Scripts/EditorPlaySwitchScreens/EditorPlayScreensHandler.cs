using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorPlayScreensHandler : MonoBehaviour
{
    public EditorSwitcher editor;
    public PlayerSwitcher player;

    void Start()
    {
        editor.EditorSwitchState(true);
        player.PlayerSwitchState(false);
    }

    public void SwitchToEditor()
    {
        editor.EditorSwitchState(true);
        player.PlayerSwitchState(false);
    }

    public void SwitchToPlay()
    {
        editor.EditorSwitchState(false);
        player.PlayerPreview();
    }
}
