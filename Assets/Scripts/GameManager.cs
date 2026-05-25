using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] TextMeshProUGUI scoreText;
    int score = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();

    }
}
