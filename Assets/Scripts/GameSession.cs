using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    int gameScore = 0;

    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    
    void Awake()
    {
        // create our singleton
        int numberGameSessions = FindObjectsByType<GameSession>().Length;
        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

      void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = gameScore.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        } else
        {
            ResetGameSession();
        }
    }

    public void AddToScore(int pointsToAdd)
    {
        gameScore += pointsToAdd;
        scoreText.text = gameScore.ToString();
    }

    void TakeLife()
    {
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playerLives.ToString();
    }

    void ResetGameSession()
    {
        FindAnyObjectByType<ScenePersist>().resetScenePersists();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

}
