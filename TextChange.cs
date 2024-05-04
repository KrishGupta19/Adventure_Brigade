using UnityEngine;
using UnityEngine.UI;

public class TextChange : MonoBehaviour
{
    [SerializeField] private Text textElement;
    public float changeTime = 3f; // Time in seconds after which the text will change

    private void Start()
    {
        // Start the text changing process
        StartCoroutine(ChangeTextAfterTime());
    }

    private System.Collections.IEnumerator ChangeTextAfterTime()
    {
        // Wait for the specified time
        yield return new WaitForSeconds(changeTime);

        // Change the text to "hu"
        if(textElement != null)
        {
            textElement.text = "Avoid SpikeHead & Saw";
        }
        else
        {
            Debug.LogWarning("Text element is not assigned.");
        }
    }
}