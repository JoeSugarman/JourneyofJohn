using UnityEngine;
using UnityEngine.Tilemaps;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform platform;
    [SerializeField] private Transform startTransform;
    [SerializeField] private Transform endTransform;
   // [SerializeField] private Transform stand;
    [SerializeField] private float speed = 0.7f;

    private Vector3 target;
    private int direction = 1;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = platform.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Platform needs a Rigidbody2D");
        }
        target = endTransform.position;
    }

    private void FixedUpdate()
    {
        if (rb == null) return; // If there is no Rigidbody, return

        rb.velocity = new Vector2(Mathf.Sign(target.x - platform.position.x) * speed, 0);

        if (Vector3.Distance(target, platform.position) < 0.1f)
        {
            direction *= -1;
            target = direction == 1 ? endTransform.position : startTransform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player has collided
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the player leaves the platform
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.transform.parent = null;
        }
    }

    private void OnDrawGizmos()
    {
        if (platform != null && startTransform != null && endTransform != null)
        {
            Gizmos.DrawLine(platform.position, startTransform.position);
            Gizmos.DrawLine(platform.position, endTransform.position);
        }
    }
}