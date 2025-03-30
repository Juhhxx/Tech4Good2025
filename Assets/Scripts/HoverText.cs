using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Missions Mission;
    private GameObject _hv;
    [SerializeField] private GameObject _prefabHover;
    [SerializeField] private GameObject _canvas;
    private void Start()
    {
        _canvas = GameObject.Find("Hover Canvas");
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        InstantiateHover();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (_hv != null)
            Destroy(_hv);
    }
    private void InstantiateHover()
    {
        _hv = Instantiate(_prefabHover, _canvas.transform);

        TextMeshProUGUI tmp = _hv.GetComponentInChildren<TextMeshProUGUI>();
        tmp.text = Mission.Text;
    }

}
