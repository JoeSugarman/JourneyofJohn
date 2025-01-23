using System.Collections;
using UnityEngine;

public class TreeAI : MonoBehaviour
{
    [Header("Tree Attributes")]
    public float speed = 2f;
    // public int maxHP = 3;
    //public float flashDuration = 0.1f;

    [Header("Tree Drops")]
    public GameObject woodLog;
    public int collectibleCount = 3;

    //private int currentHP;
    private Rigidbody2D rb;
    private SpriteRenderer SpriteRenderer;
    //private bool isFlashing = false;
    private Health health;


    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        rb = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        //Instantiate(woodLog, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    private void Update()
    {
        dropWood();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("TreesWall"))
        {
            speed = -speed;
            Flip();
        }
    }

    private void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void TakeDamage(float damage)
    {
        health.TakeDamage(damage);

        if (health.currentHealth <= 0)
        {
            Die();
        }
    }


    private void Die()
    {
        for (int i = 0; i < collectibleCount; i++)
        {
            Instantiate(woodLog, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    private void dropWood()
    {
        if (health.currentHealth <= 0)
        {
            for (int i = 0; i < collectibleCount; i++)
            {
                Instantiate(woodLog, transform.position, Quaternion.identity);
            }
        }
    }
}
