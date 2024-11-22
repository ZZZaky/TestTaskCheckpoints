using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMenu : MonoBehaviour
{
    public Canvas menuUI;
    private PlayerHandler playerHandler;

    void Start()
    {
        playerHandler = GetComponent<PlayerHandler>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerHandler.enabled = !playerHandler.enabled;
        }
    }
}
