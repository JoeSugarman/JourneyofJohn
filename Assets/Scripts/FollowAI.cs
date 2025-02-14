using UnityEngine;
using System.Collections;

public class FollowAI : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;
    public float jumpForce = 5f;
    public float followDistance = 2f;      // keep a distance from the player
    public float horizontalOffset = 0.5f;    // extra distance to keep from the player
    public float teleportDistance = 10f;     // if player is too far away, teleport to player
    public LayerMask groundLayer;

    public Transform spriteTransform;        
    public float floatingAmplitude = 0.2f;     
    public float floatingSpeed = 2f;

    private Rigidbody2D rb;
    private bool isTeleporting = false;

    private Vector3 spriteInitialLocalPos;
    private float floatingOffset;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        if (spriteTransform != null)
        {
            
            float yOffset = Mathf.Sin(Time.time * floatingSpeed + floatingOffset) * floatingAmplitude;
            spriteTransform.localPosition = spriteInitialLocalPos + new Vector3(0, yOffset, 0);
        }
    }

    void FixedUpdate()
    {
        // if the player is too far away, teleport to the player
        if (Vector2.Distance(transform.position, player.position) > teleportDistance && !isTeleporting)
        {
            StartCoroutine(TeleportToPlayer());
        }

        // checking if the AI is grounded
        RaycastHit2D groundInfo = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, groundLayer);
        bool isGrounded = groundInfo.collider != null;

        // calculate the distance between the AI and the player
        float distance = (player.position.x + horizontalOffset) - transform.position.x;

        // when the player is too far away, move towards the player
        if (Mathf.Abs(distance) > followDistance)
        {
            rb.velocity = new Vector2(Mathf.Sign(distance) * speed, rb.velocity.y);
        }
        else
        {
            // if the AI is close enough to the player, stop moving
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        // check if there is a ledge in front of the AI, then jump
        RaycastHit2D ledgeInfo = Physics2D.Raycast(transform.position + Vector3.right * Mathf.Sign(rb.velocity.x), Vector2.down, 1.1f, groundLayer);
        if (!ledgeInfo.collider && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    // teleport the AI to the player
    IEnumerator TeleportToPlayer()
    {
        isTeleporting = true;
        yield return new WaitForSeconds(3f);
        if (Vector2.Distance(transform.position, player.position) > teleportDistance)
        {
            transform.position = player.position;
            rb.velocity = Vector2.zero;
        }
        isTeleporting = false;
    }


}
