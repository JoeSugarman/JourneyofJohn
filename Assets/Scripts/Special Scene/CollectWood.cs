using UnityEngine;

public class CollectWood : MonoBehaviour
{
    private SpecialSceneGameManager gameManager;

    private void Start()
    {
        // Find the GameManager in the scene
        gameManager = FindObjectOfType<SpecialSceneGameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.IncrementCounter();

            Destroy(gameObject);
        }
    }
}
