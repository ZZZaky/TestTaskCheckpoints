using TMPro;
using UnityEngine;
using Zenject;

/// <summary>
/// Player's UI
/// </summary>
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

    /// <summary>
    /// Switching player's UI's state to new state
    /// </summary>
    /// <param name="state">New state</param>
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

    /// <summary>
    /// On passing checkpoint by player
    /// </summary>
    public void PassingCheckpoints()
    {
        if (!playerUIState) {  return; }
        checkpointsCounter.text = (int.Parse(checkpointsCounter.text) + 1).ToString();
    }

    /// <summary>
    /// On finishing lap by player
    /// </summary>
    public void FinishLap()
    {
        if (!playerUIState || !lapsCounter.enabled ) { return; }
        lapsCounter.text = (int.Parse(lapsCounter.text) + 1).ToString();
    }

    /// <summary>
    /// Reset UI's passed checkpoints' counter
    /// </summary>
    public void ResetPassedCheckpoints()
    {
        checkpointsCounter.text = "0";
    }

    /// <summary>
    /// Reset UI's info
    /// </summary>
    private void ResetUI()
    {
        checkpointsCounter.text = "0";
        lapsCounter.text = "0";
    }
}
