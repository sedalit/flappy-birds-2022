using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioClip FlySound;
    public AudioClip ScoreAdded;
    public AudioClip DamageTaken;

    [SerializeField] private AudioSource soundManager;

    public static void Play(AudioClip audio)
    {
        if (Instance.soundManager.isPlaying)
        {
            var newAudioSource = Instance.gameObject.AddComponent<AudioSource>();
            newAudioSource.clip = audio;
            newAudioSource.Play();
            return;
        }
        Instance.soundManager.clip = audio;
        Instance.soundManager.Play();
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
