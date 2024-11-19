using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public CharacterController playerController;
    public PlayerMovement playerMovement;
    public Camera playerCamera;
    public AudioListener playerAudioListener;

    public void PlayerSwitchState(bool state)
    {
        playerController.enabled = state;
        playerMovement.enabled = state;
        playerCamera.enabled = state;
        playerAudioListener.enabled = state;
    }

    public void PlayerPreview()
    {
        playerController.enabled = false;
        playerMovement.enabled = false;
        playerCamera.enabled = true;
        playerAudioListener.enabled = true;
    }

    public void PlayerPlay()
    {
        PlayerSwitchState(true);
    }
}
