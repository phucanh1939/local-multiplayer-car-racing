using System;
using GG.Events;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Attach to player/car game object to raise event when player/car reach the checkpoint
/// </summary>
public class GameManager : MonoBehaviour
{
    [Header("Listen to Events")]
    [SerializeField] private StringEventChannelSO _eventPlayerReachCheckpoint;

    [Header("UI")]
    [SerializeField] private GameObject _popupEndGame;
    [SerializeField] private TextMeshProUGUI _textEndGame;

    private void Start()
    {
        HidePopupEndGame();
    }

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

    // ReSharper disable once UnusedMember.Global
    /// <summary>
    /// Callback when user press play again button
    /// </summary>
    public void OnButtonPlayAgainPressed()
    {
        HidePopupEndGame();
        ResumeGame();
        RestartGame();
    }

    private void HidePopupEndGame()
    {
        _popupEndGame.SetActive(false);
    }

    private void ShowPopupEndGame(string winnerName)
    {
        _textEndGame.text = winnerName + " Won!";
        _popupEndGame.SetActive(true);
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