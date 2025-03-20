
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_Sideways : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    [SerializeField]private float damage;
    [SerializeField] private bool upAndDown = false;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;


    private void Awake()
    {
        if (!upAndDown)
        {
            leftEdge = transform.position.x - movementDistance;
            rightEdge = transform.position.x + movementDistance;
        }
        else if (upAndDown)
        {
            leftEdge = transform.position.y - movementDistance;
            rightEdge = transform.position.y + movementDistance;
        }

    }

    private void Update()
    {
        if (upAndDown)
        {
            if (movingLeft)
            {
                if (transform.position.y > leftEdge)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
                }
                else
                {
                    movingLeft = false;
                }
            }
            else
            {
                if (transform.position.y < rightEdge)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
                }
                else
                {
                    movingLeft = true;
                }
            }
        }
        else
        {
            if (movingLeft)
            {
                if (transform.position.x > leftEdge)
                {
                    transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
                }
                else
                {
                    movingLeft = false;
                }
            }
            else
            {
                if (transform.position.x < rightEdge)
                {
                    transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
                }
                else
                {
                    movingLeft = true;
                }
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
