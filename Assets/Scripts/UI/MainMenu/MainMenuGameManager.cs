using UnityEngine;

public class MainMenuGameManager : MonoBehaviour
{
    public static MainMenuGameManager Instance;
    public int currentLevel = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Load progress when the GameManager starts
        LoadProgress();
    }

    public void SaveProgress()
    {
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        PlayerPrefs.Save();
    }

    public void LoadProgress()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        Debug.Log("Progress Loaded. Current Level: " + currentLevel);
    }
}
