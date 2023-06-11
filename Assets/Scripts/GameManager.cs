using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] CanvasController canvasController;
    bool gamePaused = false;
    int brickCount;
    int ballCount;
    void Start()
    {
        brickCount = GameObject.FindGameObjectsWithTag("Brick").Length;
        Debug.Log("Brick Count : " + brickCount);
        SetBallCount(1);
        AudioManager.Instance.PlaySound(SoundType.BGMusic);
    }
    void SetBallCount(int _ballCount)
    {
        ballCount = _ballCount;
    }
    public void DeleteBall()
    {
        if (ballCount > 1)
            ballCount--;
        else
            LevelFailed();
    }
    public void DeleteBrick()
    {
        if (brickCount > 1)
            brickCount--;
        else
            LevelComplete();
    }
    public void PauseGame()
    {
        if (gamePaused)
        {
            AudioManager.Instance.ResumeMusic();
            canvasController.DisablePauseUI();
            LevelManager.Instance.UnfreezeGame();
        }
        else
        {
            AudioManager.Instance.PauseMusic();
            canvasController.EnablePauseUI();
            LevelManager.Instance.FreezeGame();
        }
        gamePaused = !gamePaused;
    }
    void LevelFailed()
    {
        canvasController.GameOverScreen();
        AudioManager.Instance.PauseMusic();
        AudioManager.Instance.PlaySound(SoundType.GameOver);
        LevelManager.Instance.FreezeGame();
    }
    void LevelComplete()
    {
        canvasController.LevelSuccessUI();
        AudioManager.Instance.PauseMusic();
        AudioManager.Instance.PlaySound(SoundType.LevelComplete);
        LevelManager.Instance.FreezeGame();
    }
    public void RestartLevel()
    {
        LevelManager.Instance.UnfreezeGame();
        LevelManager.Instance.RestartLevel();
    }
    public void NextLevel()
    {
        LevelManager.Instance.UnfreezeGame();
        LevelManager.Instance.LoadNextLevel();
    }
    public void LoadMainMenu()
    {
        LevelManager.Instance.UnfreezeGame();
        AudioManager.Instance.PlaySound(SoundType.MenuMusic);
        LevelManager.Instance.LoadMainMenu();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
}
