using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("GameOver")]
    [SerializeField] private GameObject gameOverScreen; //reference to the game over screen
    [SerializeField] private AudioClip gameOverSound; //sound for game over

    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen; //reference to the pause screen

    private void Awake()
    {
        gameOverScreen.SetActive(false); //hide the game over screen
        pauseScreen.SetActive(false); //hide the pause screen
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseScreen.activeInHierarchy)
                PauseGame(false); //toggle the pause screen
            else
                PauseGame(true); //toggle the pause screen
        }
    }


    #region Game Over
    public void GameOver()
    {
        gameOverScreen.SetActive(true); //show the game over screen
        SoundManager.instance.PlaySound(gameOverSound); //play the game over sound
    }

    //game over functions
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //reload the current scene
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0); //reload the current scene
    }

    public void Quit()
    {
        Application.Quit(); //reload the current scene

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; //stop the game in the editor
        #endif
    }
    #endregion

    #region Pause

    public void PauseGame(bool status)
    {
        //if status == true, pause | if status == false, unpause
        pauseScreen.SetActive(status); //show the pause screen

        Time.timeScale = status ? 0 : 1; //pause or unpause the game
    }

    public void SoundVolume()
    {
        SoundManager.instance.changeSoundVolume(0.1f);
    }

    public void MusicVolume()
    {
        SoundManager.instance.changeMusicVolume(0.1f);
    }

    #endregion

    #region main menu
    public void Level()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene(1); //reload the current scene
    }

    #endregion
}
