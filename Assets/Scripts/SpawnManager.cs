using System.Collections;
using UnityEngine;

public class UI_Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;  // The UI element prefab
    public RectTransform centerPoint; // The UI center they should face
    public RectTransform[] spawnPoints; // UI spawn positions

    public float initialSpawnRate = 2f;  // Start time between spawns
    public float spawnRateMultiplier = 0.95f; // Faster spawns over time
    public float minSpawnRate = 0.2f; // Limit to prevent infinite speed-up

    private float spawnRate;

    private void Start()
    {
        spawnRate = initialSpawnRate;
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnObject();
            yield return new WaitForSeconds(spawnRate);
            
            // Increase spawn speed over time
            spawnRate = Mathf.Max(spawnRate * spawnRateMultiplier, minSpawnRate);
        }
    }

    private void SpawnObject()
    {
        if (spawnPoints.Length == 0 || objectToSpawn == null || centerPoint == null) return;

        // Pick a random spawn point
        RectTransform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instantiate the object inside the Canvas
        GameObject spawned = Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity, spawnPoint.parent);

        // Get RectTransform
        RectTransform spawnedRect = spawned.GetComponent<RectTransform>();

        // Set position to match the spawn point
        spawnedRect.anchoredPosition = spawnPoint.anchoredPosition;

        // Convert UI positions to world space for LookAt() to work
        Vector3 worldSpawnPos = spawnedRect.position;
        Vector3 worldCenterPos = centerPoint.position;

        // Make it look at the center using LookAt()
        spawned.transform.LookAt(worldCenterPos);

        // Adjust rotation to only rotate on the Z axis for UI
        Vector3 eulerRotation = spawned.transform.eulerAngles;
        spawned.transform.rotation = Quaternion.Euler(0, 0, eulerRotation.y);
    }
}
