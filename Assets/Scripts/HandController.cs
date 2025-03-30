using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HandController : MonoBehaviour
{
    public Transform centerPoint; // The middle point the hands surge toward
    public float moveSpeed = 5f; // Speed of movement
    public float maxDistance = 1.5f; // Max range before stopping
    public float holdTime = 3f; // Time to hold position before returning

    private Vector3 spawnPoint;
    private Vector3 targetPosition;
    private bool returning = false;
    public Material newSprite; // Assign this in the Inspector
    private Image spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<Image>(); // Get the sprite renderer
        if (centerPoint == null)
        {
            centerPoint = GameObject.Find("CenterPoint").transform;
        }
        spawnPoint = transform.position; // Save spawn position
        Vector3 direction = (centerPoint.position - spawnPoint).normalized; 
        targetPosition = centerPoint.position - direction * (maxDistance * 0.5f);
        StartCoroutine(MoveToTarget());
    }

    IEnumerator MoveToTarget()
    {
        float elapsedTime = 0f;
        Vector3 startPos = transform.position;

        while (elapsedTime < 1f)
        {
            transform.position = Vector3.Lerp(startPos, targetPosition, elapsedTime);
            elapsedTime += Time.deltaTime * moveSpeed;
            yield return null;
        }

        transform.position = targetPosition; // Ensure final position is precise
        yield return new WaitForSeconds(holdTime);

        if (!returning)
        {
            StartCoroutine(ReturnToSpawn());
        }
    }

    public void GetFood()
    {
        if (!returning)
        {
            returning = true;
            StopAllCoroutines();
            StartCoroutine(ReturnToSpawn());
        }
    }

    IEnumerator ReturnToSpawn()
    {
        float elapsedTime = 0f;
        Vector3 startPos = transform.position;

        while (elapsedTime < 1f)
        {
            transform.position = Vector3.Lerp(startPos, spawnPoint, elapsedTime);
            elapsedTime += Time.deltaTime * moveSpeed;
            yield return null;
        }

        Destroy(gameObject); // Destroy after reaching spawn point
    }
    public void ChangeSprite()
    {
        if (newSprite != null)
        {
            spriteRenderer.material = newSprite;
        }
    }
    private void FinalReport()
    {
        
    }
}
