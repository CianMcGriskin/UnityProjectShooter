using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float moveSpeed = 1f;
    private float health;
    public float maxHealth = 100f;

    public Slider healthBarSlider; // Reference to the health bar slider

    void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        healthBarSlider.maxValue = maxHealth; // Set the max value of the health bar slider
        healthBarSlider.value = health; // Set the initial value of the health bar slider
    }

    void Update()
    {
        if (health <= 0)
            Destroy(gameObject);

        rb.velocity = new Vector2(-moveSpeed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBarSlider.value = health; // Update the value of the health bar slider
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
