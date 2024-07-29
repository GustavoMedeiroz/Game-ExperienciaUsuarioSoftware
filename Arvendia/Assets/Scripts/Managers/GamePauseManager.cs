using UnityEngine;

public class GamePauseManager : MonoBehaviour
{
    private bool isPaused = false;

    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0; // Pausa o jogo
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1; // Retoma o jogo
        isPaused = false;
    }
}
