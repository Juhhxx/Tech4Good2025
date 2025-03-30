using UnityEngine;
using System.Collections;

public class RandomSoundPlayer : MonoBehaviour
{
    public AudioSource audioSource; // Assign in the Inspector
    public float minTime = 2f; // Minimum delay between sounds
    public float maxTime = 10f; // Maximum delay between sounds

    private void Start()
    {
        if (audioSource == null)
        {
            Debug.LogError("AudioSource not assigned!");
            return;
        }
        StartCoroutine(PlaySoundRandomly());
    }

    private IEnumerator PlaySoundRandomly()
    {
        while (true)
        {
            float waitTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
            
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}
