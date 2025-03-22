using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
   [Header ("Health")]
   [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField]private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    [Header ("Components")]
    [SerializeField] private Behaviour[] components;
    private bool invulnerable;

    [Header ("Death Sound")]
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip hurtSound;
    public GameObject woodLog;

    [Header("cart")]
    [SerializeField] private GameObject playerwithcart;
   

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();

    }
    public void TakeDamage(float _damage) { 
        if(invulnerable) return;
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
            SoundManager.instance.PlaySound(hurtSound);
        }
        else
        {
            if (!dead) 
            { 
                

                ////player death
                //if(GetComponent<PlayerMovement>() != null)
                //    GetComponent<PlayerMovement>().enabled = false;

                ////emeny death
                //if (GetComponentInParent<EnemyPatrol>() != null)
                //    GetComponentInParent<EnemyPatrol>().enabled = false;

                //if (GetComponent<MeleeEnemy>() != null)
                //    GetComponent<MeleeEnemy>().enabled = false;

                foreach (Behaviour component in components)
                {
                    component.enabled = false;
                }

                anim.SetBool("grounded", true);
                anim.SetTrigger("die");

                dead = true;
                if (gameObject.name.Contains("treeGenie1"))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        float xOffset = (i - 1) * 0.5f; // Adjust spacing between logs
                        Vector3 spawnPosition = transform.position + new Vector3(xOffset, 1.0f, 0);
                        Instantiate(woodLog, spawnPosition, Quaternion.identity);
                    }
                }
                if (gameObject.name.Contains("treeGenie2"))
                {
                    for (int i = 0; i < 5; i++)
                    {
                        float xOffset = (i - 1) * 0.5f; // Adjust spacing between logs
                        Vector3 spawnPosition = transform.position + new Vector3(xOffset, 1.0f, 0);
                        Instantiate(woodLog, spawnPosition, Quaternion.identity);
                    }
                }
                if (gameObject.name.Contains("treeGenie3"))
                {
                    for (int i = 0; i < 1; i++)
                    {
                        float xOffset = (i - 1) * 0.5f; // Adjust spacing between logs
                        Vector3 spawnPosition = transform.position + new Vector3(xOffset, 1.0f, 0);
                        Instantiate(woodLog, spawnPosition, Quaternion.identity);
                    }
                }
                SoundManager.instance.PlaySound(deathSound);
            }
        }
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    public void Respawn()
    {
        dead = false;

        AddHealth(startingHealth);
        anim.ResetTrigger("Die");
        anim.Play("idle");
        StartCoroutine(Invunerability());

        //activate all components
        foreach (Behaviour component in components)
        {
            component.enabled = true;
        }

        //GameObject cart = GameObject.Find("Cart");
        GameObject cart = GameObject.Find("cart");
        if(cart != null)
            Destroy(cart);
    }
    private IEnumerator Invunerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration/(numberOfFlashes*2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
        invulnerable = false;
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

}
