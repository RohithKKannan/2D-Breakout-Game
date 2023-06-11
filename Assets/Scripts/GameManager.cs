using UnityEngine;
using System.Collections.Generic;
public enum PowerUp
{
    Ball2x
};
public class GameManager : MonoBehaviour
{
    [SerializeField] CanvasController canvasController;
    [SerializeField] GameObject ballPrefab;
    [SerializeField] GameObject[] powerUps;
    [SerializeField] List<BallController> ballList;
    [SerializeField] float popupForce = 2f;
    bool gamePaused = false;
    int brickCount;
    [SerializeField] int ballCount;
    int powerUpCount;
    int indexCount = 2;
    void Start()
    {
        brickCount = GameObject.FindGameObjectsWithTag("Brick").Length;
        powerUpCount = powerUps.Length;
        AudioManager.Instance.PlaySound(SoundType.BGMusic);
        ballList = new List<BallController>();
        RefreshBallList();
    }
    void RefreshBallList()
    {
        ballList.Clear();
        foreach (BallController item in GameObject.FindObjectsOfType<BallController>())
        {
            ballList.Add(item);
        }
        ballCount = ballList.Count;
    }
    public void DeleteBall(int _index)
    {
        int i = -1;
        i = ballList.FindIndex(item => item.GetIndex() == _index);
        if (i != -1)
            Destroy(ballList[i].gameObject);
        ballList.RemoveAt(i);
        ballCount--;
        if (ballCount == 0)
            LevelFailed();
    }
    public void DeleteBrick(Vector2 position)
    {
        if (brickCount > 1)
            brickCount--;
        else
            LevelComplete();
        if (Random.Range(1, 10) == 1)
        {
            SpawnPowerUp(position);
        }
    }
    public void SpawnPowerUp(Vector2 position)
    {
        int index = Random.Range(0, powerUpCount);
        if (index < powerUpCount)
        {
            GameObject newPowerUp = Instantiate(powerUps[index], position, Quaternion.identity);
            newPowerUp.GetComponent<Rigidbody2D>().AddForce(Vector2.up * popupForce, ForceMode2D.Impulse);
        }
    }
    public void PowerUpPicked(PowerUp powerUp)
    {
        switch (powerUp)
        {
            case PowerUp.Ball2x:
                DoubleTheBalls();
                break;
            default: break;
        }
    }
    void DoubleTheBalls()
    {
        List<BallController> tempList = new List<BallController>(ballList);
        foreach (BallController item in tempList)
        {
            GameObject newBall = Instantiate(ballPrefab, item.transform.position, Quaternion.identity);
            BallController newBallController = newBall.GetComponent<BallController>();
            newBallController.JustSpawned(indexCount++);
            newBallController.SetDirection(-1 * item.GetDirection());
            newBall.transform.localScale = new Vector3(1, 1, 1);
            ballCount++;
            ballList.Add(newBallController);
        }
        tempList.Clear();
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
