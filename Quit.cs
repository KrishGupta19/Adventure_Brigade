using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    [SerializeField] private Button b;
    // Function to be called when the button is clicked
    public void Start()
    {
        b.onClick.AddListener(s);
    }
    void s()
    {
        Application.Quit();
    }
}