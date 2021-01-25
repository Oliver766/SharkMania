using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public Transform[] prefabs;

    private Transform child;

    void Awake()
    {
        // Set child if the object already has one
        if (transform.childCount > 0)
            child = transform.GetChild(0);
    }

    void OnEnable()
    {
        // Called once the level segment is repooled

        if (child || prefabs.Length == 0)
            // Child already exists or no spawnable prefabs exist
            return;

        // The child object does't exist, create a new child
        child = Instantiate(RandomPrefab(), transform);
    }

    Transform RandomPrefab()
    {
        // Select a random prefab
        int index = UnityEngine.Random.Range(0, prefabs.Length);
        return prefabs[index];
    }
}
