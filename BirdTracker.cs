using UnityEngine;

public class BirdTracker : MonoBehaviour
{
    [SerializeField] private Bird targetBird;
    [SerializeField] private float offsetX;

    private void Update()
    {
        transform.position = new Vector3(targetBird.transform.position.x - offsetX, transform.position.y, transform.position.z);
    }

}
