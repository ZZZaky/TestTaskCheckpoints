using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHandler : MonoBehaviour
{
    private PlayerDrag playerDrag;
    private CarController carController;
    private PlayerMenu playerMenu;
    private PlayerWin playerWin;
    private PlayerUI playerUI;
    private Camera playerCamera;
    private AudioListener playerAudioListener;

    private Vector3 playerInEditorPosition;
    private Quaternion playerInEditorRotation;

    void Awake()
    {
        playerDrag = GetComponent<PlayerDrag>();
        carController = GetComponent<CarController>();
        playerMenu = GetComponent<PlayerMenu>();
        playerWin = GetComponent<PlayerWin>();
        playerUI = GetComponent<PlayerUI>();
        playerCamera = GetComponentInChildren<Camera>();
        playerAudioListener = GetComponentInChildren<AudioListener>();
        playerInEditorPosition = transform.position;
        playerInEditorRotation = transform.rotation;
    }

    public void Activate()
    {
        playerInEditorPosition = transform.position;
        playerInEditorRotation = transform.rotation;
        playerDrag.enabled = false;
        carController.enabled = true;
        playerMenu.enabled = true;
        playerWin.enabled = true;
        playerUI.enabled = true;
        playerUI.SwitchState(true);
        playerCamera.enabled = true;
        playerAudioListener.enabled = true;
    }

    public void Deactivate()
    {
        transform.position = playerInEditorPosition;
        transform.rotation = playerInEditorRotation;
        playerDrag.enabled = true;
        carController.enabled = false;
        playerMenu.enabled = false;
        playerWin.enabled = false;
        playerUI.SwitchState(false);
        playerUI.enabled = false;
        playerCamera.enabled = false;
        playerAudioListener.enabled = false;
    }
}
