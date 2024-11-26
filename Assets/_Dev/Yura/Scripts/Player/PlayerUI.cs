using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class PlayerUI : MonoBehaviour
{
    public GameObject playerUI;
    public TextMeshProUGUI checkpointsCounter;
    public GameObject laps;
    public TextMeshProUGUI lapsCounter;

    private bool playerUIState;
    [Inject] CheckpointManager checkpointManager;

    void Awake()
    {
        playerUIState = false;
        playerUI.SetActive(playerUIState);
    }

    public void SwitchState(bool state)
    {
        if (playerUIState && !state) { ResetUI(); }
        playerUI.SetActive(state);
        if (!playerUIState && state) 
        {
            laps.SetActive(checkpointManager.ringRoad);
            if (checkpointManager.ringRoad) { lapsCounter.enabled = checkpointManager.ringRoad; }
        }
        playerUIState = state;
    }

    public void PassingCheckpoints()
    {
        if (!playerUIState) {  return; }
        checkpointsCounter.text = (int.Parse(checkpointsCounter.text) + 1).ToString();
    }

    public void FinishLap()
    {
        if (!playerUIState || !lapsCounter.enabled ) { return; }
        lapsCounter.text = (int.Parse(lapsCounter.text) + 1).ToString();
    }

    public void ResetPassedCheckpoints()
    {
        checkpointsCounter.text = "0";
    }

    private void ResetUI()
    {
        checkpointsCounter.text = "0";
        lapsCounter.text = "0";
    }
}
