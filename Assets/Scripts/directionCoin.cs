using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class directionCoin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object that collided with the coin is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroy the coin
            Destroy(gameObject);
        }
    }
}
