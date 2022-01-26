using UnityEngine;

[RequireComponent(typeof(Bird), typeof(Collider2D))]
public class BirdCollisionHandler : MonoBehaviour
{
    private Bird bird;

    private void Start()
    {
        bird = GetComponent<Bird>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ScoreZone scoreZone))
        {
            bird.AddScore();
            return;
        }
        bird.Die();
    }
}
