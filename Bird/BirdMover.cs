using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float minRotationZ;
    [SerializeField] private float maxRotationZ;
    [SerializeField] private float tapForce;

    private Vector3 startPosition;
    private Quaternion minRotation;
    private Quaternion maxRotation;
    private Rigidbody2D rigidbody;

    private void Start()
    {
        startPosition = transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
        minRotation = Quaternion.Euler(0, 0, minRotationZ);
        maxRotation = Quaternion.Euler(0, 0, maxRotationZ);
        ResetBird();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.velocity = new Vector2(movementSpeed, 0);
            transform.rotation = maxRotation;
            rigidbody.AddForce(Vector2.up * tapForce, ForceMode2D.Force);
            SoundManager.Play(SoundManager.Instance.FlySound);
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, minRotation, rotationSpeed * Time.deltaTime);
    }

    public void ResetBird()
    {
        transform.position = startPosition;
        transform.rotation = Quaternion.Euler(Vector3.zero);
        rigidbody.velocity = Vector2.zero;
    }
}
