using UnityEngine;

public class DisappearObj : MonoBehaviour
{
    public float disappearTime = 3f; 

    private void Start()
    {
        
        StartCoroutine(DisappearAfterTime());
    }

    private System.Collections.IEnumerator DisappearAfterTime()
    {
       
        yield return new WaitForSeconds(disappearTime);

   
        gameObject.SetActive(false);
    }
}