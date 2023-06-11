using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject levelSuccessScreen;
    public void Pause()
    {
        AudioManager.Instance.PlaySound(SoundType.ButtonClick);
        gameManager.PauseGame();
    }
    public void Resume()
    {
        AudioManager.Instance.PlaySound(SoundType.ButtonClick);
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
        AudioManager.Instance.PlaySound(SoundType.ButtonClick);
        gameManager.RestartLevel();
    }
    public void LevelSuccessUI()
    {
        levelSuccessScreen.SetActive(true);
    }
    public void NextLevel()
    {
        AudioManager.Instance.PlaySound(SoundType.ButtonClick);
        gameManager.NextLevel();
    }
    public void MainMenu()
    {
        AudioManager.Instance.PlaySound(SoundType.ButtonClick);
        gameManager.LoadMainMenu();
    }
}
