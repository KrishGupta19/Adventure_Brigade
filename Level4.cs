using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Level4 : MonoBehaviour
{
    [SerializeField] private Button b;
    // Function to be called when the button is clicked
    public void Start()
    {
        b.onClick.AddListener(s);
    }
    void s()
    {
        SceneManager.LoadScene("Level4"); 
    }
}
