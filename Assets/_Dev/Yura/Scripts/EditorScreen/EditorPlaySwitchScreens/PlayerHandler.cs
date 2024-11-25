using UnityEngine;
using Zenject;

public class PlayerHandler : MonoBehaviour
{
    private PlayerDrag playerDrag;
    private CharacterController characterController;
    private PlayerMovement playerMovement;
    private PlayerMenu playerMenu;
    private PlayerWin playerWin;
    private Camera playerCamera;
    private AudioListener playerAudioListener;

    private Vector3 playerInEditorPosition;
    private Quaternion playerInEditorRotation;

    void Awake()
    {
        playerDrag = GetComponent<PlayerDrag>();
        characterController = GetComponent<CharacterController>();
        playerMovement = GetComponent<PlayerMovement>();
        playerMenu = GetComponent<PlayerMenu>();
        playerWin = GetComponent<PlayerWin>();
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
        characterController.enabled = true;
        playerMovement.enabled = true;
        playerMenu.enabled = true;
        playerWin.enabled = true;
        playerCamera.enabled = true;
        playerAudioListener.enabled = true;
    }

    public void Deactivate()
    {
        transform.position = playerInEditorPosition;
        transform.rotation = playerInEditorRotation;
        playerDrag.enabled = true;
        characterController.enabled = false;
        playerMovement.enabled = false;
        playerMenu.enabled = false;
        playerWin.enabled = false;
        playerCamera.enabled = false;
        playerAudioListener.enabled = false;
    }
}
