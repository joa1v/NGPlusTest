using NGPlus.SaveSystem;
using NGPlus.Singleton;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelManager _levelManager;

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
    }

}
