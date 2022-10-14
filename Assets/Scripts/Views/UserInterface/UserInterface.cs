using Snake.Scripts.Views.UserInterface;
using UnityEngine;

public class UserInterface : MonoBehaviour
{
    [SerializeField]
    private MainPanel _mainPanel;

    [SerializeField]
    private LosePanel _losePanel;

    [SerializeField]
    private WinPanel _winPanel;

    [SerializeField]
    private GameplayPanel _gameplayPanel;

    public void ShowMainPanel()
    {
        _mainPanel?.ShowPanel();
    }

    public void HideMainPanel()
    {
        _mainPanel?.HidePanel();
    }

    public void ShowLosePanel()
    {
        _losePanel?.ShowPanel();
    }

    public void ShowWinPanel()
    {
        _winPanel?.ShowPanel();
    }

    public void HideEndGamePanel()
    {
        _losePanel?.HidePanel();
    }

    public void ShowGameplayPanel()
    {
        _gameplayPanel?.ShowPanel();
    }

    public void HideGameplayPanel() => _gameplayPanel?.HidePanel();

    public void UpdateScore(int score)
    {
        _gameplayPanel?.UpdateScore(score);
    }

    public void UpdateLevel(int level)
    {
        _gameplayPanel?.UpdateLevel(level);
    }
}