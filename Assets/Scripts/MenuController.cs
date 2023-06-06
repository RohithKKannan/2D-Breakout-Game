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

    }
    public void SettingsClicked()
    {
        animator.SetTrigger("SettingsOn");
    }
    public void SettingsToMenu()
    {
        animator.SetTrigger("SettingsOff");
    }
    public void QuitGame()
    {

    }
}
