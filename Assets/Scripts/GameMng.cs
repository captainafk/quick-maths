using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMng : MonoBehaviour
{
    public Text healthText;
    public static int health = 10;
    public static int score = 0;

    // A boolean to disable user input after the game is over
    public static bool isGameRunning;

    // A gameOverPanelPrefab is instantiated when the game is over in order to show score and such
    [SerializeField]
    private GameObject gameOverPanelPrefab;

    private GameObject gameOverPanel;

    private GameObject gameOverScoreText;
    private GameObject highScoreText;

    [SerializeField]
    private Canvas canvas;

    // Start is called before the first frame update
    private void Start()
    {
        health = 10;
        score = 0;
        isGameRunning = true;
    }

    // Update is called once per frame
    private void Update()
    {
        // Update the health value every frame
        if (health > 0)
        {
            healthText.text = "Health: " + health.ToString();
        }
        // If health falls below zero, end the game
        else
        {
            healthText.text = "Health: 0";
            StartCoroutine(EndTheGame());
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    private IEnumerator EndTheGame()
    {
        if (isGameRunning)
        {
            // Disable the inputs when the game is over
            isGameRunning = false;

            // Get the high score and update it if necessary
            SavedData.LoadHighScore();

            if (score > SavedData.highScore)
            {
                SavedData.highScore = score;
                PlayerPrefs.SetInt("highScore", SavedData.highScore);
            }

            // Play the "Game Over" sound
            GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>().GameOver();

            // Instantiate gameOverPanel and set it as a child of canvas
            gameOverPanel = Instantiate(gameOverPanelPrefab,
                                        new Vector3(0, 0, 0),
                                        Quaternion.identity,
                                        canvas.transform);
            gameOverPanel.transform.localPosition = new Vector3(0, 0, 0);

            // Show the score when the game is over
            gameOverScoreText = canvas.transform.Find("GameOverPanel(Clone)").gameObject
                                      .transform.Find("GameOverScoreText").gameObject;
            gameOverScoreText.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + score.ToString();

            // Show the score when the game is over
            highScoreText = canvas.transform.Find("GameOverPanel(Clone)").gameObject
                                  .transform.Find("HighScoreText").gameObject;
            highScoreText.GetComponent<TMPro.TextMeshProUGUI>().text = "High Score: " + SavedData.highScore.ToString();

            // Make the scale of the panel 0, then make it larger via tweening
            gameOverPanel.transform.localScale = new Vector3(0, 0, 0);
            LeanTween.scale(gameOverPanel, new Vector3(0.3f, 0.5f, 1), 0.25f);
        }

        yield return new WaitForSeconds(5);

        // Return to the main menu
        SceneManager.LoadScene("Menu");
    }
}