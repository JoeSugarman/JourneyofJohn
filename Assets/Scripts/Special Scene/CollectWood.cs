using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectWood : MonoBehaviour
{
    public WoodChecker woodChecker;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Debug.Log("Get the log");
            woodChecker.CollectWood();
            Destroy(gameObject);
        }
    }


}
