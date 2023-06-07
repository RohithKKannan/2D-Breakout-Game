using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject levelSuccessScreen;
    public void Pause()
    {
        gameManager.PauseGame();
    }
    public void Resume()
    {
        gameManager.PauseGame();
    }
    public void EnablePauseUI()
    {
        pauseScreen.SetActive(true);
    }
    public void DisablePauseUI()
    {
        pauseScreen.SetActive(false);
    }
    public void GameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }
    public void Restart()
    {
        gameManager.RestartLevel();
    }
    public void LevelSuccessUI()
    {
        levelSuccessScreen.SetActive(true);
    }
    public void NextLevel()
    {
        gameManager.NextLevel();
    }
    public void MainMenu()
    {
        gameManager.LoadMainMenu();
    }
}
