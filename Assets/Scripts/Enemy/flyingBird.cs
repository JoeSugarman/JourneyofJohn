using UnityEngine;

public class flyingBird : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity; //make sure that the bird can attack only after the cooldown time has passed

    private Health playerHealth;

    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (PlayerInsight())
        {

            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("flying");
            }
        }
        


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Fireball"))
        {
            anim.SetTrigger("Die");
        }
    }

    private bool PlayerInsight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x, boxCollider.bounds.size, 0, Vector2.left, 0, playerLayer);
        
        if(hit.collider != null)
        {
            playerHealth = hit.transform.GetComponent<Health>();
            
        }

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x, boxCollider.bounds.size);
    }

    private void DamagePlayer()
    {
        if (PlayerInsight())
        {
            playerHealth.TakeDamage(damage);
        }

    }
}
