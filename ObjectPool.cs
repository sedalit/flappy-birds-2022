using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject container;
    [SerializeField] private int count;

    private Camera camera;
    private List<GameObject> pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        camera = Camera.main;
        for (int i = 0; i < count; i++)
        {
            GameObject spawned = Instantiate(prefab, container.transform);
            spawned.SetActive(false);
            pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = pool.FirstOrDefault(p => p.activeSelf == false);
        return result != null;
    }

    protected void DisableObjectAbroadScreen()
    {
        Vector3 disablePoint = camera.ViewportToWorldPoint(new Vector2(0, 0.5f));
        foreach (var obj in pool)
        {
            if (obj.transform.position.x < disablePoint.x) obj.SetActive(false);
        }
    }

    public void ResetPool()
    {
        foreach (var obj in pool)
        {
            obj.SetActive(false);
        }
    }
}
