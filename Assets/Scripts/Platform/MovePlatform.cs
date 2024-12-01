using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private Transform platform;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float startDelay = 0f;

    private Vector3 nextPosition;
    private bool canMove = false;

    // Start is called before the first frame update
    void Start()
    {
        nextPosition = pointB.position;
        StartCoroutine(StartDelay());
    }

    private IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(startDelay);
        canMove = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (!canMove) return;

        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);

        if(transform.position == pointA.position)
        {
            nextPosition = pointB.position;
        }
        else if (transform.position == pointB.position)
        {
            nextPosition = pointA.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.transform.parent = null;
        }
    }
}
