using System.Collections;
using UnityEngine;

public class TreeAI : MonoBehaviour
{
    [Header("Tree Attributes")]
    public float speed = 2f;
    public float raycastDistance = 0.9f;
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
        float height = GetComponent<Collider2D>().bounds.size.y; 
        Vector2 boxSize = new Vector2(0.05f, height); 

        RaycastHit2D hitLeft = Physics2D.BoxCast(transform.position, boxSize, 0, Vector2.left, raycastDistance);
        RaycastHit2D hitRight = Physics2D.BoxCast(transform.position, boxSize, 0, Vector2.right, raycastDistance);
        //RaycastHit2D hitLeft2 = Physics2D.BoxCast(transform.position - new Vector3(0, 5, 0), boxSize, 0, Vector2.left, raycastDistance);
        //RaycastHit2D hitRight2 = Physics2D.BoxCast(transform.position - new Vector3(0, 5, 0), boxSize, 0, Vector2.right, raycastDistance);


        //Debug.DrawRay(transform.position + Vector3.up * (height / 2), Vector2.left * raycastDistance, Color.red);
        //Debug.DrawRay(transform.position - Vector3.up * (height / 2), Vector2.left * raycastDistance, Color.red);
        //Debug.DrawRay(transform.position + Vector3.up * (height / 2), Vector2.right * raycastDistance, Color.red);
        //Debug.DrawRay(transform.position - Vector3.up * (height / 2), Vector2.right * raycastDistance, Color.red);

        if (hitLeft.collider != null && hitLeft.collider.CompareTag("Ground"))
        {
            Debug.Log("Hit left ground");
            transform.position = new Vector2(transform.position.x + 0.1f, transform.position.y);
        }
        else if (hitRight.collider != null && hitRight.collider.CompareTag("Ground"))
        {
            Debug.Log("Hit right ground");
            transform.position = new Vector2(transform.position.x - 0.1f, transform.position.y);
        }

        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    //private void Update()
    //{
    //    dropWood();
    //}

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

    //public void TakeDamage(float damage)
    //{
    //    health.TakeDamage(damage);

    //    if (health.currentHealth <= 0)
    //    {
    //        Die();
    //    }
    //}


    //private void Die()
    //{
    //    for (int i = 0; i < collectibleCount; i++)
    //    {
    //        Instantiate(woodLog, transform.position, Quaternion.identity);
    //    }

    //    Destroy(gameObject);
    //}

    //private void dropWood()
    //{
    //    if (health.currentHealth <= 0)
    //    {
    //        for (int i = 0; i < collectibleCount; i++)
    //        {
    //            Instantiate(woodLog, transform.position, Quaternion.identity);
    //        }
    //    }
    //}
}