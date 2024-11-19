using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorSwitcher : MonoBehaviour
{
    public GameObject editorScreen;
    public Camera editorCamera;
    public AudioListener editorAudioListener;

    public void EditorSwitchState(bool state)
    {
        editorScreen.SetActive(state);
        editorCamera.enabled = state;
        editorAudioListener.enabled = state;
    }
}
