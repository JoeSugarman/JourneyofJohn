using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour
{
    [SerializeField] private float upForce = 1f;
    [SerializeField] private float downForce = 1f;
    [SerializeField] private Transform up;
    [SerializeField] private Transform down;
    [SerializeField] private int damage;
    private bool chop;
    private Health playerHealth;

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.y >= up.position.y)
        {
            chop = true;
        }

        if (transform.position.y <= down.position.y)
        {
            chop = false;
        }

        if (chop)
        {
            transform.position = Vector2.MoveTowards(transform.position, down.position, downForce * Time.deltaTime);

        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, up.position, upForce * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
