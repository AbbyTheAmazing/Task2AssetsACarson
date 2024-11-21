using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [Header("Stats")]
        public PlayerMovement player;
        public float timeSurvived;
        public int enemiesKilled;
        public bool playerIsAlive = true;

    [Header("menus")] 
        public GameObject startMenu;
        public GameObject pauseMenu;

    [Header("UI")]
        public GameObject headsUpDisplay;
        public TMP_Text timer;
        public TMP_Text killCount;
        public GameObject heart1;
        public GameObject heart2;
        public GameObject heart3;
        public GameObject heart4;
        public GameObject heart5;

    [Header("Game Over")]
        public GameObject gameOverScreen;
        public TMP_Text timeSurvivedText;
        public TMP_Text enemiesKilledText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Resets all stats so the game can be replayed
        playerIsAlive = true;
        enemiesKilled = 0;
        timeSurvived = 0;
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Updates the HUD
        timeSurvived += Time.deltaTime;
        timer.text = "" + (int)timeSurvived;
        killCount.text = enemiesKilled.ToString() + "Enemies Killed";

        // ENd the game if the players health reaches 0.
        if (player.health == 0)
        {
            GameOver();
        }
    }

    public void PlayGame()
    {
        // Starts the game
        startMenu.SetActive(false);
        Time.timeScale = 1;
        headsUpDisplay.SetActive(true);
    }

    public void PauseGame()
    {
        // Pauses the game
        if (startMenu.activeInHierarchy == false && gameOverScreen.activeInHierarchy == false)
        {
            if (Time.timeScale == 0)
                {
                    pauseMenu.SetActive(false);
                    Time.timeScale = 1;
                }
            else if (Time.timeScale == 1);
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
    public void GameOver()
    {
        // Ends the game and shows the players final scores
        headsUpDisplay.SetActive(false);
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
        timeSurvivedText.text = "Time Survived: " + (int)timeSurvived + " Seconds";
        enemiesKilledText.text = "Enemies Killed: " + enemiesKilled;
    } 

    public void PlayAgain()
    {
        //Resets the scene
        Time.timeScale = 0;
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    } 
    public void ExitGame()
    {
        // Closes the game
        Debug.Log("Exit Game");
        Application.Quit();
    }
}

