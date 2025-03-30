using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private float _fallingSpeed;
    private RectTransform _rectTrans;

    private void Start()
    {
        _rectTrans = GetComponent<RectTransform>();
    }
    private void FixedUpdate()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        Vector3 curPos = _rectTrans.anchoredPosition;
        curPos.y -= _fallingSpeed;
        _rectTrans.anchoredPosition = curPos;

        if (curPos.y <= -0.46f)
            Destroy(gameObject);
    }
    public void CollectWater()
    {
        Debug.Log("AAAA");
        Destroy(gameObject);
        //Add points
    }

}
