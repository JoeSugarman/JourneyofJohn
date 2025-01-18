using UnityEngine;

public class LevelCompleteTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MainMenuGameManager.Instance.currentLevel++;
            MainMenuGameManager.Instance.SaveProgress();
            Debug.Log("Level Completed! Current Level: " + MainMenuGameManager.Instance.currentLevel);
        }
    }
}
