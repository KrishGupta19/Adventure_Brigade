using UnityEngine;
using System.Collections;

public class DisappearAndAppear : MonoBehaviour
{
    public GameObject objectToToggle;
    public float disappearTime = 2f; // Time interval for disappearing
    public float appearTime = 2f; // Time interval for appearing

    private bool isVisible = true;

    void Start()
    {
        // Start the coroutine
        StartCoroutine(ToggleObject());
    }

    IEnumerator ToggleObject()
    {
        while (true)
        {
            // Toggle visibility
            isVisible = !isVisible;
            objectToToggle.SetActive(isVisible);

            // Wait for the next interval
            yield return new WaitForSeconds(isVisible ? disappearTime : appearTime);
        }
    }
}