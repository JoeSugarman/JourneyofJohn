using System.Collections;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevelTrigger : MonoBehaviour
{
    [SerializeField] AudioClip endLevelSound;
    [SerializeField] int nextLevelIndex;
    [SerializeField] int nextLevelToUnlock;
    private AudioSource audioSource;
    private bool isTriggered = false;
    public Animator transition;
    public float transitionTime = 1f;


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
        
        if(isTriggered)
            Debug.Log("End level trigger");

        //freeze player
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if(player != null)
        {
            player.enabled = false;
        }

        //StartCoroutine(LoadNextSceneAfterDelay(audioSource.clip.length));

        //play sound
        audioSource.Play();

        if (GameProgress.Instance != null)
        {
            GameProgress.Instance.UnlockLevel(nextLevelToUnlock);
        }
        else
        {
            Debug.LogError("GameProgress.Instance is null.");
        }
        // GameProgress.Instance.UnlockLevel(nextLevelToUnlock);

        //load next level after the sound has finished playing
        StartCoroutine(LoadNextSceneAfterDelay(audioSource.clip.length));
    }

    private IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        Debug.Log("Waiting for " + delay + " seconds before loading next scene.");
        //if(Time.timeScale == 0)
        //{
        //    Time.timeScale = 1;
        //}
        yield return new WaitForSecondsRealtime(delay);
        SceneManager.LoadScene(nextLevelIndex);

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //if (MainMenuManager.Instance != null && SceneManager.GetActiveScene().name == "JapanGameScene1")
        //    MainMenuManager.Instance.isVS2Unlocked = true;
        //else if (MainMenuManager.Instance != null && SceneManager.GetActiveScene().name == "JapanGameScene2No")
        //    MainMenuManager.Instance.isVS3Point2Unlocked = true;
        //else if (MainMenuManager.Instance != null && SceneManager.GetActiveScene().name == "JapanGameScene2Yes")
        //    MainMenuManager.Instance.isVS3Point1Unlocked = true;
        //else if (MainMenuManager.Instance != null && SceneManager.GetActiveScene().name == "JapanGameScene3 (Driving)")
        //    MainMenuManager.Instance.isVS4Unlocked = true;
        //else if (MainMenuManager.Instance != null && SceneManager.GetActiveScene().name == "JapanGameScene3 (Not Driving)")
        //    MainMenuManager.Instance.isVS4Unlocked = true;
        //else if (MainMenuManager.Instance != null && SceneManager.GetActiveScene().name == "JapanGameScene5")
        //    MainMenuManager.Instance.isVSFinalUnlocked = true;
        if (MainMenuManager.Instance != null)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            Debug.Log("Current scene: " + currentSceneName);

            switch (currentSceneName)
            {
                case "JapanGameScene1":
                    MainMenuManager.Instance.isVS2Unlocked = true;
                    break;
                case "JapanGameScene2No":
                    MainMenuManager.Instance.isVS3Point2Unlocked = true;
                    break;
                case "JapanGameScene2Yes":
                    MainMenuManager.Instance.isVS3Point1Unlocked = true;
                    break;
                case "JapanGameScene3 (Driving)":
                case "JapanGameScene3 (Not Driving)":
                    MainMenuManager.Instance.isVS4Unlocked = true;
                    break;
                case "JapanGameScene5":
                    MainMenuManager.Instance.isVSFinalUnlocked = true;
                    break;
            }

        }
    }

    public void LoadNextLevelWithAnimation()
    {

    }

    //IEnumerator LoadLevel(int levelIndex)
    //{
    //    ////play 
    //    //transition.SetTrigger("Start");
    //    ////wait
    //    //yield return new WaitForSeconds(transitionTime);

    //    ////load level
    //    SceneManager.LoadScene(levelIndex);
    //}
}
