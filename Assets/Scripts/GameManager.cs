using GG.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Attach to player/car game object to raise event when player/car reach the checkpoint
/// </summary>
public class GameManager : MonoBehaviour
{
    [Header("Listen to Events")] [SerializeField]
    private StringEventChannelSO _eventPlayerReachCheckpoint;

    private void OnEnable()
    {
        _eventPlayerReachCheckpoint.onEventRaised += OnPlayerReachCheckpoint;
    }

    private void OnDisable()
    {
        _eventPlayerReachCheckpoint.onEventRaised -= OnPlayerReachCheckpoint;
    }

    private void OnPlayerReachCheckpoint(string playerTag)
    {
        Debug.Log("OnPlayerReachCheckpoint: " + playerTag);
        EndGame(playerTag);
    }

    private void ShowPopupEndGame(string winnerName)
    {
        // TODO
        Invoke(nameof(RestartGame), 1.0f);
    }

    public void PauseGame() => Time.timeScale = 0;

    public void ResumeGame() => Time.timeScale = 1;

    public void EndGame(string winnerName)
    {
        PauseGame();
        ShowPopupEndGame(winnerName);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}