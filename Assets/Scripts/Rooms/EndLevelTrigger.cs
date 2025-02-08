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

    private void Update()
    {
        //nextLevelToUnlock = chooseScene;
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
        if (MainMenuManager.Instance != null && SceneManager.GetActiveScene().name == "JapanGameScene1")
            MainMenuManager.Instance.isVS2Unlocked = true;
        else if (MainMenuManager.Instance != null && SceneManager.GetActiveScene().name == "JapanGameScene2No")
            MainMenuManager.Instance.isVS3Point2Unlocked = true;
        else if (MainMenuManager.Instance != null && SceneManager.GetActiveScene().name == "JapanGameScene2Yes")
            MainMenuManager.Instance.isVS3Point1Unlocked = true;
        else if (MainMenuManager.Instance != null && SceneManager.GetActiveScene().name == "JapanGameScene3 (Driving)")
            MainMenuManager.Instance.isVS4Unlocked = true;
        else if (MainMenuManager.Instance != null && SceneManager.GetActiveScene().name == "JapanGameScene3 (Not Driving)")
            MainMenuManager.Instance.isVS4Unlocked = true;
        else if (MainMenuManager.Instance != null && SceneManager.GetActiveScene().name == "JapanGameScene5")
            MainMenuManager.Instance.isVSFinalUnlocked = true;

    }
}
