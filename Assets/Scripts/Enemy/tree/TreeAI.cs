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

    
    void FixedUpdate()
    {
        Bounds bounds = GetComponent<Collider2D>().bounds;
        float halfWidth = bounds.extents.x;
        float halfHeight = bounds.extents.y;
        float offsetX = 0.05f;
        float offsetY = 0.05f;
        float raycastAdjust = 0.1f;


        Vector2 leftRayOrigin = new Vector2(transform.position.x - halfWidth - raycastAdjust, transform.position.y);
        Vector2 rightRayOrigin = new Vector2(transform.position.x + halfWidth + raycastAdjust, transform.position.y);
        Vector2 topLeftRayOrigin = new Vector2(transform.position.x - halfWidth, transform.position.y + halfHeight + raycastAdjust);
        Vector2 topRightRayOrigin = new Vector2(transform.position.x + halfWidth, transform.position.y + halfHeight + raycastAdjust);
        Vector2 topLeftRayOriginq = new Vector2(transform.position.x - halfWidth, transform.position.y + halfHeight * 2 + raycastAdjust);
        Vector2 topRightRayOriginq = new Vector2(transform.position.x + halfWidth, transform.position.y + halfHeight * 2 + raycastAdjust);

        RaycastHit2D hitLeft = Physics2D.Raycast(leftRayOrigin, Vector2.left, raycastDistance);
        RaycastHit2D hitRight = Physics2D.Raycast(rightRayOrigin, Vector2.right, raycastDistance);
        RaycastHit2D hitTopLeft = Physics2D.Raycast(topLeftRayOrigin, Vector2.left, raycastDistance);
        RaycastHit2D hitTopRight = Physics2D.Raycast(topRightRayOrigin, Vector2.right, raycastDistance);
        RaycastHit2D hitTopLeftq = Physics2D.Raycast(topLeftRayOrigin, Vector2.left, raycastDistance);
        RaycastHit2D hitTopRightq = Physics2D.Raycast(topRightRayOrigin, Vector2.right, raycastDistance);

        // Debug Raycast 
        Debug.DrawRay(leftRayOrigin, Vector2.left * raycastDistance, Color.green);
        Debug.DrawRay(rightRayOrigin, Vector2.right * raycastDistance, Color.green);
        Debug.DrawRay(topLeftRayOrigin, Vector2.left * raycastDistance, Color.blue);
        Debug.DrawRay(topRightRayOrigin, Vector2.right * raycastDistance, Color.blue);


        if (hitLeft.collider != null && hitLeft.collider.CompareTag("Ground"))
        {
            Debug.Log("touch left");
            transform.position = new Vector2(transform.position.x + offsetX, transform.position.y);
        }


        if (hitRight.collider != null && hitRight.collider.CompareTag("Ground"))
        {
            Debug.Log("touch right");
            transform.position = new Vector2(transform.position.x - offsetX, transform.position.y);
        }


        if (hitTopLeft.collider != null && hitTopLeft.collider.CompareTag("Ground"))
        {
            Debug.Log("touch left");
            transform.position = new Vector2(transform.position.x + offsetX, transform.position.y - offsetY);
        }


        if (hitTopRight.collider != null && hitTopRight.collider.CompareTag("Ground"))
        {
            Debug.Log("touch right");
            transform.position = new Vector2(transform.position.x - offsetX, transform.position.y - offsetY);
        }

        if (hitTopLeftq.collider != null && hitTopLeft.collider.CompareTag("Ground"))
        {
            Debug.Log("touch left");
            transform.position = new Vector2(transform.position.x + offsetX, transform.position.y - offsetY);
        }


        if (hitTopRightq.collider != null && hitTopRight.collider.CompareTag("Ground"))
        {
            Debug.Log("touch right");
            transform.position = new Vector2(transform.position.x - offsetX, transform.position.y - offsetY);
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