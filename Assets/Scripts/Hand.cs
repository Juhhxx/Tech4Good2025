using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    [SerializeField] Sprite _fullHand;
    [SerializeField] float _handSpeed = 0.5f; // Speed of movement
    public RectTransform start;
    public RectTransform end;
    public RectTransform _rectTrans;

    private bool shouldReturn = false; // Controls return movement
    private Coroutine handRoutine; // Store coroutine for stopping/restarting
    private bool isReturning = false; // Ensure return movement doesn't start multiple times

    void Start()
    {
        _rectTrans = GetComponent<RectTransform>();
        handRoutine = StartCoroutine(HandMovement());
    }

    private IEnumerator HandMovement()
    {
        Debug.Log("Hey I have started");

        float time = 0f;

        // Move forward
        while (time < 1f)
        {
            time += Time.deltaTime * _handSpeed;
            _rectTrans.anchoredPosition = Vector3.Lerp(start.anchoredPosition, end.anchoredPosition, time);
            yield return null;
        }

        Debug.Log("Reached the end!");

        // Wait for 10 seconds unless GiveFood() is called
        float waitTime = 0;
        while (waitTime < 10f && !shouldReturn)
        {
            waitTime += Time.deltaTime;
            yield return null;
        }

        Debug.Log("Returning...");
        StartReturning();
    }

    private void StartReturning()
    {
        if (!isReturning)
        {
            isReturning = true;
            handRoutine = StartCoroutine(ReturnMovement());
        }
    }

    private IEnumerator ReturnMovement()
    {
        Debug.Log("Hand is moving back!");

        float time = 1f; // Start from the end position

        while (time > 0f)
        {
            time -= Time.deltaTime * _handSpeed;
            _rectTrans.anchoredPosition = Vector3.Lerp(end.anchoredPosition, start.anchoredPosition, time);
            yield return null;
        }

        Debug.Log("Hand disappeared!");
        Destroy(gameObject);
    }

    public void GiveFood()
    {
        Debug.Log("u clicked me!!");

        // Change sprite
        Image image = gameObject.GetComponent<Image>();
        image.sprite = _fullHand;

        // Stop the forward movement and start returning immediately
        if (handRoutine != null)
        {
            StopCoroutine(handRoutine);
        }
        shouldReturn = true;
        StartReturning();
    }
}
