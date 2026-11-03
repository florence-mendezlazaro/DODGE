using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool isGamePaused = false;

    [Header("DefaultUI")]
    [SerializeField] private GameObject defaultUI;
    [SerializeField] private Button pauseButton;

    [Header("PauseUI")]
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        Time.timeScale = 1f;

        defaultUI.SetActive(true);
        pauseButton.onClick.AddListener(() => GamePaused());

        pauseUI.SetActive(false);
        resumeButton.onClick.AddListener(() => GamePaused());
        quitButton.onClick.AddListener(() => Debug.Log("Quit To Menu"));
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
}