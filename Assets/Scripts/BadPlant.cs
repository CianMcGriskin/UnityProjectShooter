using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadPlant : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-moveSpeed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
