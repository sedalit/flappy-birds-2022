using UnityEngine;

public class PipeGenerator : ObjectPool
{
    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] private float secondsBetweenSpawn;
    [SerializeField] private float maxSpawnPositionY;
    [SerializeField] private float minSpawnPositionY;

    private float elapsedTime = 0;

    private void Start()
    {
        Initialize(spawnPrefab);
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject pipe))
            {
                elapsedTime = 0;
                float spawnPositionY = Random.Range(minSpawnPositionY, maxSpawnPositionY);
                Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);
                pipe.SetActive(true);
                pipe.transform.position = spawnPoint;
                DisableObjectAbroadScreen();
            }
        }
    }
}
