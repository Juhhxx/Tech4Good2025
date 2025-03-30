using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class WaterSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawningPoints;
    [SerializeField] private GameObject _waterPrefab;

    private void Start()
    {
        StartCoroutine(SpawnWater());
    }

    private IEnumerator SpawnWater()
    {
        while (true)
        {
            Transform spawnpoint = _spawningPoints.RandomElement();

            Instantiate(_waterPrefab,spawnpoint.position,Quaternion.identity,spawnpoint.parent);

            float sec = Random.Range(0.5f,2f);

            yield return new WaitForSeconds(sec);
        }
        
    }
    

}
