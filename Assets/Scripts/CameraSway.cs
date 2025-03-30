using UnityEngine;

public class CameraSway : MonoBehaviour
{
    [Header("Rotation Sway Settings")]
    public bool enableRotationSway = true;
    public float rotationSwaySpeed = 1.0f;
    public float rotationSwayAmount = 2.0f;

    [Header("Position Sway Settings")]
    public bool enablePositionSway = false;
    public float positionSwaySpeed = 1.0f;
    public float positionSwayAmount = 0.1f;

    private float timeCounter = 0f;
    private Quaternion originalRotation;
    private Vector3 originalPosition;

    void Start()
    {
        originalRotation = transform.rotation;
        originalPosition = transform.position;
    }

    void Update()
    {
        timeCounter += Time.deltaTime;

        if (enableRotationSway)
        {
            float swayOffset = Mathf.Sin(timeCounter * rotationSwaySpeed) * rotationSwayAmount;
            Quaternion swayRotation = Quaternion.Euler(0, swayOffset, 0); // Yaw sway (side to side)
            transform.rotation = originalRotation * swayRotation;
        }

        if (enablePositionSway)
        {
            float swayOffset = Mathf.Sin(timeCounter * positionSwaySpeed) * positionSwayAmount;
            transform.position = originalPosition + new Vector3(swayOffset, 0, 0); // Moves side to side
        }
    }
}
