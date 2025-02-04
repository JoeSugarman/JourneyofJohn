using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelTrigger : MonoBehaviour
{
    [SerializeField] AudioClip endLevelSound;
    [SerializeField] int nextLevelIndex;
    [SerializeField] int nextLevelToUnlock;
    private AudioSource audioSource;
    private bool isTriggered = false;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = endLevelSound;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(isTriggered || !other.CompareTag("Player")) return;

        isTriggered = true;

        //freeze player
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if(player != null)
        {
            player.enabled = false;
        }

        //play sound
        audioSource.Play();

        GameProgress.Instance.UnlockLevel(nextLevelToUnlock);

        //load next level after the sound has finished playing
        StartCoroutine(LoadNextSceneAfterDelay(audioSource.clip.length));
    }

    private IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(nextLevelIndex);
       //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
