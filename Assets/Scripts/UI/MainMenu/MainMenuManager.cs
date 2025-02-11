using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instance;
    [SerializeField] private Button VSIntro;
    [SerializeField] private Button VS1;
    [SerializeField] private Button VS2;
    [SerializeField] private Button VS3Point1;
    [SerializeField] private Button VS3Point2;
    [SerializeField] private Button VS4;
    [SerializeField] private Button VS4Point5;
    [SerializeField] private Button VS5;
    [SerializeField] private Button VSFinal;
    [SerializeField] private Button GS1;
    [SerializeField] private Button GS2Point1;
    [SerializeField] private Button GS2Point2;
    [SerializeField] private Button GS3Point1;
    [SerializeField] private Button GS3Point2;
    [SerializeField] private Button GS4;
    [SerializeField] private Button GS5;

    public bool isVSIntroUnlocked = true;
    public bool isVS1Unlocked = false;
    public bool isVS2Unlocked = false;
    public bool isVS3Point1Unlocked = false;
    public bool isVS3Point2Unlocked = false;
    public bool isVS4Unlocked = false;
    public bool isVS4Point5Unlocked = false;
    public bool isVS5Unlocked = false;
    public bool isVSFinalUnlocked = false;
    public bool isGS1Unlocked = false;
    public bool isGS2Point1Unlocked = false;
    public bool isGS2Point2Unlocked = false;
    public bool isGS3Point1Unlocked = false;
    public bool isGS3Point2Unlocked = false;
    public bool isGS4Unlocked = false;
    public bool isGS5Unlocked = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadUnlockStates();
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        
    }

    void LateUpdate() 
    {
        ISVS1Unlocked();
        ISVS2Unlocked();
        ISVS3Point1Unlocked();
        ISVS3Point2Unlocked();
        ISVS4Unlocked();
        ISVS4Point5Unlocked();
        ISVS5Unlocked();
        ISVSFinalUnlocked();
        ISGS1Unlocked();
        ISGS2Point1Unlocked();
        ISGS2Point2Unlocked();
        ISGS3Point1Unlocked();
        ISGS3Point2Unlocked();
        ISGS4Unlocked();
        ISGS5Unlocked();

    }

    void ISVS1Unlocked()
    {
        if(isVS1Unlocked == true)
            VS1.interactable = true;
        else
            VS1.interactable = false;
    }

    void ISVS2Unlocked()
    {
        if (isVS2Unlocked == true)
            VS2.interactable = true;
        else
            VS2.interactable = false;
    }

    void ISVS3Point1Unlocked()
    {
        if (isVS3Point1Unlocked == true)
            VS3Point1.interactable = true;
        else
            VS3Point1.interactable = false;
    }

    void ISVS3Point2Unlocked()
    {
        if (isVS3Point2Unlocked == true)
            VS3Point2.interactable = true;
        else
            VS3Point2.interactable = false;
    }

    void ISVS4Unlocked()
    {
        if (isVS4Unlocked == true)
            VS4.interactable = true;
        else
            VS4.interactable = false;
    }

    void ISVS4Point5Unlocked()
    {
        if (isVS4Point5Unlocked == true)
            VS4Point5.interactable = true;
        else
            VS4Point5.interactable = false;
    }

    void ISVS5Unlocked()
    {
        if (isVS5Unlocked == true)
            VS5.interactable = true;
        else
            VS5.interactable = false;
    }

    void ISVSFinalUnlocked()
    {
        if (isVSFinalUnlocked == true)
            VSFinal.interactable = true;
        else
            VSFinal.interactable = false;
    }

    void ISGS1Unlocked()
    {
        if (isGS1Unlocked == true)
            GS1.interactable = true;
        else
            GS1.interactable = false;
    }

    void ISGS2Point1Unlocked()
    {
        if (isGS2Point1Unlocked == true)
            GS2Point1.interactable = true;
        else
            GS2Point1.interactable = false;
    }

    void ISGS2Point2Unlocked()
    {
        if (isGS2Point2Unlocked == true)
            GS2Point2.interactable = true;
        else
            GS2Point2.interactable = false;
    }

    void ISGS3Point1Unlocked()
    {
        if (isGS3Point1Unlocked == true)
            GS3Point1.interactable = true;
        else
            GS3Point1.interactable = false;
    }

    void ISGS3Point2Unlocked()
    {
        if (isGS3Point2Unlocked == true)
            GS3Point2.interactable = true;
        else
            GS3Point2.interactable = false;
    }

    void ISGS4Unlocked()
    {
        if (isGS4Unlocked == true)
            GS4.interactable = true;
        else
            GS4.interactable = false;
    }

    void ISGS5Unlocked()
    {
        if (isGS5Unlocked == true)
            GS5.interactable = true;
        else
            GS5.interactable = false;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "_MainMenu") // Replace with your main menu scene name
        {
            AssignButtonReferences();
            UpdateButtonStates();
        }
    }

    private void AssignButtonReferences()
    {
        VSIntro = GameObject.Find("IntroButton (Legacy)").GetComponent<Button>();
        VS1 = GameObject.Find("VN1Button (Legacy)").GetComponent<Button>();
        VS2 = GameObject.Find("VN2Button (Legacy)").GetComponent<Button>();
        VS3Point1 = GameObject.Find("VN3V1Button (Legacy)").GetComponent<Button>();
        VS3Point2 = GameObject.Find("VN3V2Button (Legacy)").GetComponent<Button>();
        VS4 = GameObject.Find("VN4Button (Legacy)").GetComponent<Button>();
        VS4Point5 = GameObject.Find("VN4.5Button (Legacy)").GetComponent<Button>();
        VS5 = GameObject.Find("VN5Button (Legacy)").GetComponent<Button>();
        VSFinal = GameObject.Find("FInalSceneButton (Legacy)").GetComponent<Button>();
        GS1 = GameObject.Find("GM1Button (Legacy)").GetComponent<Button>();
        GS2Point1 = GameObject.Find("GM2YesButton (Legacy)").GetComponent<Button>();
        GS2Point2 = GameObject.Find("GM2NoButton (Legacy)").GetComponent<Button>();
        GS3Point1 = GameObject.Find("GM3V1Button (Legacy)").GetComponent<Button>();
        GS3Point2 = GameObject.Find("GM3V2Button (Legacy)").GetComponent<Button>();
        GS4 = GameObject.Find("GM4Button (Legacy)").GetComponent<Button>();
        GS5 = GameObject.Find("GM5Button (Legacy)").GetComponent<Button>();
    }

    private void UpdateButtonStates()
    {
        VSIntro.interactable = isVSIntroUnlocked;
        VS1.interactable = isVS1Unlocked;
        VS2.interactable = isVS2Unlocked;
        VS3Point1.interactable = isVS3Point1Unlocked;
        VS3Point2.interactable = isVS3Point2Unlocked;
        VS4.interactable = isVS4Unlocked;
        VS4Point5.interactable = isVS4Point5Unlocked;
        VS5.interactable = isVS5Unlocked;
        VSFinal.interactable = isVSFinalUnlocked;
        GS1.interactable = isGS1Unlocked;
        GS2Point1.interactable = isGS2Point1Unlocked;
        GS2Point2.interactable = isGS2Point2Unlocked;
        GS3Point1.interactable = isGS3Point1Unlocked;
        GS3Point2.interactable = isGS3Point2Unlocked;
        GS4.interactable = isGS4Unlocked;
        GS5.interactable = isGS5Unlocked;
    }

    public void SaveUnlockStates()
    {
        PlayerPrefs.SetInt("isVSIntroUnlocked", isVSIntroUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("isVS1Unlocked", isVS1Unlocked ? 1 : 0);
        PlayerPrefs.SetInt("isVS2Unlocked", isVS2Unlocked ? 1 : 0);
        PlayerPrefs.SetInt("isVS3Point1Unlocked", isVS3Point1Unlocked ? 1 : 0);
        PlayerPrefs.SetInt("isVS3Point2Unlocked", isVS3Point2Unlocked ? 1 : 0);
        PlayerPrefs.SetInt("isVS4Unlocked", isVS4Unlocked ? 1 : 0);
        PlayerPrefs.SetInt("isVS4Point5Unlocked", isVS4Point5Unlocked ? 1 : 0);
        PlayerPrefs.SetInt("isVS5Unlocked", isVS5Unlocked ? 1 : 0);
        PlayerPrefs.SetInt("isVSFinalUnlocked", isVSFinalUnlocked ? 1 : 0);
        PlayerPrefs.SetInt("isGS1Unlocked", isGS1Unlocked ? 1 : 0);
        PlayerPrefs.SetInt("isGS2Point1Unlocked", isGS2Point1Unlocked ? 1 : 0);
        PlayerPrefs.SetInt("isGS2Point2Unlocked", isGS2Point2Unlocked ? 1 : 0);
        PlayerPrefs.SetInt("isGS3Point1Unlocked", isGS3Point1Unlocked ? 1 : 0);
        PlayerPrefs.SetInt("isGS3Point2Unlocked", isGS3Point2Unlocked ? 1 : 0);
        PlayerPrefs.SetInt("isGS4Unlocked", isGS4Unlocked ? 1 : 0);
        PlayerPrefs.SetInt("isGS5Unlocked", isGS5Unlocked ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void LoadUnlockStates()
    {
        isVSIntroUnlocked = PlayerPrefs.GetInt("isVSIntroUnlocked", 1) == 1;
        isVS1Unlocked = PlayerPrefs.GetInt("isVS1Unlocked", 0) == 1;
        isVS2Unlocked = PlayerPrefs.GetInt("isVS2Unlocked", 0) == 1;
        isVS3Point1Unlocked = PlayerPrefs.GetInt("isVS3Point1Unlocked", 0) == 1;
        isVS3Point2Unlocked = PlayerPrefs.GetInt("isVS3Point2Unlocked", 0) == 1;
        isVS4Unlocked = PlayerPrefs.GetInt("isVS4Unlocked", 0) == 1;
        isVS4Point5Unlocked = PlayerPrefs.GetInt("isVS4Point5Unlocked", 0) == 1;
        isVS5Unlocked = PlayerPrefs.GetInt("isVS5Unlocked", 0) == 1;
        isVSFinalUnlocked = PlayerPrefs.GetInt("isVSFinalUnlocked", 0) == 1;
        isGS1Unlocked = PlayerPrefs.GetInt("isGS1Unlocked", 0) == 1;
        isGS2Point1Unlocked = PlayerPrefs.GetInt("isGS2Point1Unlocked", 0) == 1;
        isGS2Point2Unlocked = PlayerPrefs.GetInt("isGS2Point2Unlocked", 0) == 1;
        isGS3Point1Unlocked = PlayerPrefs.GetInt("isGS3Point1Unlocked", 0) == 1;
        isGS3Point2Unlocked = PlayerPrefs.GetInt("isGS3Point2Unlocked", 0) == 1;
        isGS4Unlocked = PlayerPrefs.GetInt("isGS4Unlocked", 0) == 1;
        isGS5Unlocked = PlayerPrefs.GetInt("isGS5Unlocked", 0) == 1;
    }

    //public Button[] levelButtons;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    MainMenuGameManager.Instance.LoadProgress(); 
    //    int unlockedLevel = MainMenuGameManager.Instance.currentLevel;

    //    for (int i = 0; i < levelButtons.Length; i++)
    //    {
    //        if (i + 1 <= unlockedLevel)
    //        {
    //            levelButtons[i].interactable = true;
    //        }
    //        else
    //        {
    //            levelButtons[i].interactable = false;
    //        }
    //    }
    //    Debug.Log("Current Level: " + MainMenuGameManager.Instance.currentLevel);

    //}

    public void resetAllLevel()
    {
        Debug.Log("Resetting all levels");
        isVSIntroUnlocked = true;
        isVS1Unlocked = false;
        isVS2Unlocked = false;
        isVS3Point1Unlocked = false;
        isVS3Point2Unlocked = false;
        isVS4Unlocked = false;
        isVS4Point5Unlocked = false;
        isVS5Unlocked = false;
        isVSFinalUnlocked = false;
        isGS1Unlocked = false;
        isGS2Point1Unlocked = false;
        isGS2Point2Unlocked = false;
        isGS3Point1Unlocked = false;
        isGS3Point2Unlocked = false;
        isGS4Unlocked = false;
        isGS5Unlocked = false;

        SaveUnlockStates();
        AssignButtonReferences();
        UpdateButtonStates();
    }

    //private void Start()
    //{
    //    // Load progress from the GameManager
    //    if (MainMenuGameManager.Instance != null)
    //    {
    //        MainMenuGameManager.Instance.LoadProgress();
    //        UpdateLevelButtons();
    //    }
    //}

    //private void UpdateLevelButtons()
    //{
    //    int unlockedLevel = MainMenuGameManager.Instance.currentLevel;


    //    for (int i = 0; i < levelButtons.Length; i++)
    //    {
    //        levelButtons[i].interactable = (i + 1 <= unlockedLevel);
    //    }
    //}
}
