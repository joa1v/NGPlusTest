using NGPlus.SaveSystem;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelManager _levelManager; //i could use zenject for these 2 lines but i dont think i have enough time
    [SerializeField] private Timer _timer;

    private void Start()
    {
        SaveManager.LoadGame();
        Cursor.lockState = CursorLockMode.Confined;
        StartGame();
    }

    private void OnDisable()
    {
        SaveManager.SaveGame();
    }

    private void StartGame()
    {
        _levelManager.StartLevel();
        _timer.StartTimer();
    }

}
