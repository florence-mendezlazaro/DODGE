using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isGamePaused = false;

    private bool isGameOver = false;

    [Header("DefaultUI")]
    [SerializeField] private GameObject defaultUI;
    [SerializeField] private Button pauseButton;

    [Header("PauseUI")]
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button quitButton1;

    [Header("GameOverUI")]
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button quitButton2;

    private void Awake()
    {
        Time.timeScale = 1f;

        defaultUI.SetActive(true);
        pauseButton.onClick.AddListener(() => GamePaused());

        pauseUI.SetActive(false);
        resumeButton.onClick.AddListener(() => GamePaused());
        quitButton1.onClick.AddListener(() => Debug.Log("Quit To Menu"));

        gameOverUI.SetActive(false);
        retryButton.onClick.AddListener(() => SceneManager.LoadScene(0));
        quitButton2.onClick.AddListener(() => Debug.Log("Quit To Menu"));
    }

    private void GamePaused()
    {
        if (isGamePaused)
        {
            Time.timeScale = 1f;

            defaultUI.SetActive(true);
            
            pauseUI.SetActive(false);

            isGamePaused = false;
        }
        else
        {
            Time.timeScale = 0f;

            pauseUI.SetActive(true);

            defaultUI.SetActive(false);

            isGamePaused = true;
        }
    }

    private void GameOver()
    {
        if (isGameOver)
        {
            Time.timeScale = 0f;

            gameOverUI.SetActive(true);

            defaultUI.SetActive(false);
        }
    }

    public void SetGameStatus(bool status)
    {
        isGameOver = status;

        GameOver();
    }
}