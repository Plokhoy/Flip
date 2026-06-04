using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] public GameObject _gameOverPanel;
    int score = 0;

    public enum GameState
    {
        Start,
        Playing,
        Dead
    }
    public GameState _gameState;

    private void Awake()
    {
        Instance = this;
        _gameState = GameState.Start;
        _gameOverPanel.SetActive(false);
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();

    }
}
