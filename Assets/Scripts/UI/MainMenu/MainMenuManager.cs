using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button[] levelButtons;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuGameManager.Instance.LoadProgress();
        int unlockedLevel = MainMenuGameManager.Instance.currentLevel;

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 <= unlockedLevel)
            {
                levelButtons[i].interactable = true;
            }
            else
            {
                levelButtons[i].interactable = false;
            }
        }
        Debug.Log("Current Level: " + MainMenuGameManager.Instance.currentLevel);

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
