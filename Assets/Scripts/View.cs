using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class View : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tmp;
    [SerializeField] private GameManager _gameManager;

    private void Update()
    {
        UpdateUI();
    }
    private void UpdateUI()
    {
        _tmp.text = string.Format("Day {0}\n\nManpower : {1}/100\nBuilding Materials : {2}\nWater : {3}\nFood : {4}\nMedicine : {5}\n\nActive Tasks : {6}",
        _gameManager.Turn, 
        _gameManager.Manpower, 
        _gameManager.Resources[Resources.Building],
        _gameManager.Resources[Resources.Water],
        _gameManager.Resources[Resources.Food],
        _gameManager.Resources[Resources.Medicine],
        _gameManager.ActiveMissions);
    }
}
