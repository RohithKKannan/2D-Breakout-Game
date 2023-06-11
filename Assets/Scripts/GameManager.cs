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
            canvasController.DisablePauseUI();
            LevelManager.Instance.UnfreezeGame();
        }
        else
        {
            canvasController.EnablePauseUI();
            LevelManager.Instance.FreezeGame();
        }
        gamePaused = !gamePaused;
    }
    void LevelFailed()
    {
        canvasController.GameOverScreen();
        LevelManager.Instance.FreezeGame();
    }
    void LevelComplete()
    {
        canvasController.LevelSuccessUI();
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
