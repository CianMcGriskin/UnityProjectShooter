using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    private BoxCollider2D coll;
    private Rigidbody2D rb;
    public HealthBar healthbar;
    public int maxHealth = 100;
    public float currentHealth;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        float dirY = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, dirY * moveSpeed);

        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

    }

    void OnTriggerEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(20);
        }
        else if (collision.gameObject.CompareTag("BadPlant"))
        {
            StartCoroutine(BadPlantEffectCoroutine()); // Start coroutine for bad plant effect
            Destroy(collision.gameObject); // Destroy the bad plant object
        }
        else if (collision.gameObject.CompareTag("GoodPlant"))
        {
            StartCoroutine(GoodPlantEffectCoroutine()); // Start coroutine for good plant effect
            Destroy(collision.gameObject); // Destroy the good plant object
        }
    }

    IEnumerator BadPlantEffectCoroutine()
    {
        // Set player's scale to twice the size for 10 seconds
        transform.localScale = new Vector3(2f, 2f, 1f);
        yield return new WaitForSeconds(10f);
        // Reset player's scale to original size after 10 seconds
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

    IEnumerator GoodPlantEffectCoroutine()
    {
        // Set player's scale to half the size for 10 seconds
        transform.localScale = new Vector3(0.5f, 0.5f, 1f);
        yield return new WaitForSeconds(10f);
        // Reset player's scale to original size after 10 seconds
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

    void TakeDamage(int damage) {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);

        if (healthbar.GetHealth() <= 0)
            Die();
    }

    private void Die()
    {
    }
}
