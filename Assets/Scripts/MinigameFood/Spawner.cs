using UnityEngine;
public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnpoints;
    [SerializeField] private Transform _middlePoint;
    [SerializeField] private GameObject _hand;
    [SerializeField] private Canvas _canvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnHand()
    {
        Transform chosenSpawnPoint = _spawnpoints[Random.Range(0,_spawnpoints.Length)];

        GameObject newHand = Instantiate(_hand, chosenSpawnPoint.position, Quaternion.identity, _canvas.transform);
        newHand.transform.LookAt(_middlePoint);
        
    }
}
