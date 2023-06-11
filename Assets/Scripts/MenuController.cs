using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject SettingsMenu;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void StartGame()
    {
        AudioManager.Instance.PlaySound(SoundType.ButtonClick);
        LevelManager.Instance.LoadNextLevel();
    }
    public void SettingsClicked()
    {
        AudioManager.Instance.PlaySound(SoundType.ButtonClick);
        animator.SetTrigger("SettingsOn");
    }
    public void SettingsToMenu()
    {
        AudioManager.Instance.PlaySound(SoundType.ButtonClick);
        animator.SetTrigger("SettingsOff");
    }
    public void QuitGame()
    {
        AudioManager.Instance.PlaySound(SoundType.ButtonClick);
        LevelManager.Instance.ExitGame();
    }
    public void ChangeMusicVolume(float value)
    {
        AudioManager.Instance.SetMusicVolume(value);
    }
    public void ChangeSfxVolume(float value)
    {
        AudioManager.Instance.SetSfxVolume(value);
    }
}
