using NGPlus.SaveSystem;
using NGPlus.Singleton;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private LevelManager _levelManager; //i could use zenject for these 2 lines but i dont think i have enough time
    [SerializeField] private Timer _timer;
    private bool _isReset;

    private void Start()
    {
        Time.timeScale = 1;
        SaveManager.LoadGame();
        Cursor.lockState = CursorLockMode.Confined;
        StartGame();
    }

    private void OnDisable()
    {
        if (_isReset)
            return;

        SaveManager.SaveGame();
    }

    private void StartGame()
    {
        _levelManager.StartLevel();
        _timer.StartTimer();
    }

    public void ResetGame()
    {
        _isReset = true;

        PlayerPrefs.DeleteAll();
        int buildId = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(buildId);
    }

}
