using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform target; // Assigned by the spawner

    private void Update()
    {
        if (target != null)
        {
            transform.LookAt(target.position);
            Vector3 eulerRotation = transform.eulerAngles;
            transform.rotation = Quaternion.Euler(0, 0, eulerRotation.y); // Ensure only Z-axis rotation
        }
    }
}
