using UnityEngine;
using Zenject;

public class PlayerHandler : MonoBehaviour
{
    private CharacterController characterController;
    private PlayerMovement playerMovement;
    private PlayerMenu playerMenu;
    private Camera playerCamera;
    private AudioListener playerAudioListener;

    void Start()
    {
        characterController = this.GetComponent<CharacterController>();
        playerMovement = this.GetComponent<PlayerMovement>();
        playerMenu = this.GetComponent<PlayerMenu>();
        playerCamera = this.GetComponentInChildren<Camera>();
        playerAudioListener = this.GetComponentInChildren<AudioListener>();
    }

    public void Deactivate()
    {
        characterController.enabled = false;
        playerMovement.enabled = false;
        playerMenu.enabled = false;
        playerCamera.enabled = false;
        playerAudioListener.enabled = false;
    }

    public void Activate()
    {
        characterController.enabled = true;
        playerMovement.enabled = true;
        playerMenu.enabled = true;
        playerCamera.enabled = true;
        playerAudioListener.enabled = true;
    }
}
