using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class ShootingScript : MonoBehaviour
{
    
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public float bulletLifetime = 2.0f; // Lifetime of bullets in seconds

    public TMP_Text scoreText;
    private int score = 0;
    private float elapsedTime = 0f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.FindKeyOnCurrentKeyboardLayout("q").wasPressedThisFrame)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            Destroy(bullet, bulletLifetime);
        }

        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 1f)
        {
            // Increase the score by 1 every second
            score++;
            scoreText.text = "Score: " + score.ToString();
            elapsedTime = 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if collision is with an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the enemy and the bullet
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
