using UnityEngine;
using Zenject;

public class PlayerHandler : MonoBehaviour
{
    [Inject] private SelectedObjectManager selectedObjectManager;
    private CharacterController characterController;
    private PlayerMovement playerMovement;
    private Camera playerCamera;
    private AudioListener playerAudioListener;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerMovement = GetComponent<PlayerMovement>();
        playerCamera = GetComponentInChildren<Camera>();
        playerAudioListener = GetComponentInChildren<AudioListener>();
    }

    public void Deactivate()
    {
        characterController.enabled = false;
        playerMovement.enabled = false;
        playerCamera.enabled = false;
        playerAudioListener.enabled = false;

        selectedObjectManager.isOn = true;
    }

    public void Activate()
    {
        characterController.enabled = true;
        playerMovement.enabled = true;
        playerCamera.enabled = true;
        playerAudioListener.enabled = true;

        selectedObjectManager.isOn = false;
    }
}
