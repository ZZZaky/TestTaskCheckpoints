using UnityEngine;
using Zenject;

public class PlayerHandler : MonoBehaviour
{
    private CharacterController characterController;
    private PlayerMovement playerMovement;
    private Camera playerCamera;
    private AudioListener playerAudioListener;

    void Start()
    {
        characterController = this.GetComponent<CharacterController>();
        playerMovement = this.GetComponent<PlayerMovement>();
        playerCamera = this.GetComponentInChildren<Camera>();
        playerAudioListener = this.GetComponentInChildren<AudioListener>();
    }

    public void Deactivate()
    {
        characterController.enabled = false;
        playerMovement.enabled = false;
        playerCamera.enabled = false;
        playerAudioListener.enabled = false;
    }

    public void Activate()
    {
        characterController.enabled = true;
        playerMovement.enabled = true;
        playerCamera.enabled = true;
        playerAudioListener.enabled = true;
    }
}
