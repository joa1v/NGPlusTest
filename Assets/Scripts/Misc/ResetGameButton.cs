using UnityEngine;
using UnityEngine.UI;

public class ResetGameButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void Start()
    {
        _button.onClick.AddListener(ResetGame);
    }
    private void ResetGame()
    {
        GameManager.Instance.ResetGame();
    }
}
