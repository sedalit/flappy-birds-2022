using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird playerBird;
    [SerializeField] private PipeGenerator pipeGenerator;
    [SerializeField] private StartScreen startScreen;
    [SerializeField] private GameOverScreen gameOverScreen;

    private void Start()
    {
        Time.timeScale = 0;
        startScreen.Open();
    }

    private void OnEnable()
    {
        startScreen.PlayButtonClick += OnPlayButtonClicked;
        gameOverScreen.RestartButtonClick += OnRestartButtonClicked;
        playerBird.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        startScreen.PlayButtonClick -= OnPlayButtonClicked;
        gameOverScreen.RestartButtonClick -= OnRestartButtonClicked;
        playerBird.GameOver -= OnGameOver;
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        playerBird.ResetPlayer();
    }

    public void OnPlayButtonClicked()
    {
        startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClicked()
    {
        gameOverScreen.Close();
        pipeGenerator.ResetPool();
        StartGame();
    }

    public void OnGameOver()
    {
        Time.timeScale = 0;
        gameOverScreen.Open();
    }
}
