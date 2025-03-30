using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    [SerializeField] private GameObject _brickPrefab;
    private List<GameObject> _bricks;

    private void Start()
    {
        _bricks = new List<GameObject>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Building");
            InstantiateBrick();

            if (transform.childCount == 25)
                CleanBricks();
        }
    }
    private void InstantiateBrick()
    {
        _bricks.Add(Instantiate(_brickPrefab, transform));
    }
    private void CleanBricks()
    {
        for (int i = 0; i < _bricks.Count; i++)
        {
            Destroy(_bricks[i]);
        }
        _bricks.Clear();
        // Add point
    }
}
