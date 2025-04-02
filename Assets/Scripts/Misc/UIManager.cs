using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private LevelManager _levelManager;

    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _defeatPanel;

    private void Start()
    {
        SubscribeToLevelState();
    }

    private void SubscribeToLevelState()
    {
        _levelManager.OnLevelWin += ShowWinPanel;
        _levelManager.OnLevelDefeat += ShowDefeatPanel;
    }

    private void ShowWinPanel()
    {
        _winPanel.SetActive(true);
    }

    private void ShowDefeatPanel()
    {
        _defeatPanel.SetActive(true);
    }
}
