using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class View : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tmpManpwr;
    [SerializeField] private TextMeshProUGUI _tmpBuilding;
    [SerializeField] private TextMeshProUGUI _tmpWater;
    [SerializeField] private TextMeshProUGUI _tmpFood;
    [SerializeField] private TextMeshProUGUI _tmpMedicine;
    [SerializeField] private GameManager _gameManager;

    private void Update()
    {
        UpdateUI();
    }
    private void UpdateUI()
    {
        _tmpManpwr.text = _gameManager.Manpower.ToString();
        _tmpBuilding.text = _gameManager.Resources[Resources.Building].ToString();
        _tmpWater.text = _gameManager.Resources[Resources.Water].ToString();
        _tmpFood.text = _gameManager.Resources[Resources.Food].ToString();
        _tmpMedicine.text = _gameManager.Resources[Resources.Medicine].ToString();
    }
}
