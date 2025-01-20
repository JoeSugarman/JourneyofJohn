using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeAI : MonoBehaviour
{
    public float moveSpeed;
    public GameObject[] wayPoints;

    int NextWayPoint = 1;
    float distToPoint;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        distToPoint = Vector2.Distance(transform.position, wayPoints[NextWayPoint].transform.position);

        transform.position = Vector2.MoveTowards(transform.position, wayPoints[NextWayPoint].transform.position, moveSpeed * Time.deltaTime);

        if (distToPoint < 0.2f) 
        {
            TakeTurn();
        }
    }

    void TakeTurn()
    {
        Vector3 currRot = transform.eulerAngles;
        currRot.z += wayPoints[NextWayPoint].transform.eulerAngles.z;
        transform.eulerAngles = currRot;
        ChooseNextWayPoint();
    }

    void ChooseNextWayPoint()
    {
        NextWayPoint++;

        if(NextWayPoint == wayPoints.Length)
        {
            NextWayPoint = 0;
        }
    }
}
