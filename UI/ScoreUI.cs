using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private Bird playerBird;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text maxScoreText;

    private void OnEnable()
    {
        playerBird.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        playerBird.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        scoreText.text = score.ToString();
        maxScoreText.text = "Best: " + playerBird.MaxScore.ToString();
    }
}
