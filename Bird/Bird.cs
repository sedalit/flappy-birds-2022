using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged;

    private BirdMover mover;
    private int score;
    private int maxScore;
    private bool isAlive;

    public int MaxScore => maxScore;
    public bool IsAlive => isAlive;

    private void Start()
    {
        mover = GetComponent<BirdMover>();
        Saver<int>.TryLoad("Saved Game", ref maxScore);
    }

    public void ResetPlayer()
    {
        score = 0;
        ScoreChanged?.Invoke(score);
        mover.ResetBird();
    }

    public void AddScore()
    {
        score++;
        if (score > maxScore) maxScore = score;
        SoundManager.Play(SoundManager.Instance.ScoreAdded);
        ScoreChanged?.Invoke(score);
    }

    public void Die()
    {
        Saver<int>.Save("Saved Game", maxScore);
        SoundManager.Play(SoundManager.Instance.DamageTaken);
        GameOver?.Invoke();
    }
}
