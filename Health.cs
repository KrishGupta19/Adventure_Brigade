using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage)
    {
        if (!dead)
        {
            currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

            if (currentHealth > 0)
            {
                anim.SetTrigger("Hurt");
                StartCoroutine(Invulnerability());
            }
            else
            {
                Die();
            }
        }
    }

    private void Die()
    {
        dead = true;
        anim.SetTrigger("Die");

        // If the object with this script is a player
        if (GetComponent<PlayerMovement>() != null)
        {
            // Disable player movement
            GetComponent<PlayerMovement>().enabled = false;
            // Load the "RetryLose" scene
            SceneManager.LoadScene("RetryLose");
        }
        // If the object with this script is a MeleeEnemy
        else if (GetComponent<MeleeEnemy>() != null)
        {
            // Disable the MeleeEnemy script
            GetComponent<MeleeEnemy>().enabled = false;
            // Load the "RetryW" scene
            //SceneManager.LoadScene("RetryW");
        }
        // If the object with this script is neither a player nor a MeleeEnemy, do nothing
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    private IEnumerator Invulnerability()
    {
        // Flashing effect during invulnerability
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }
}
