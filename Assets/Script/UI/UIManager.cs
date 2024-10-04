using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private AudioClip gameOverSound;
    public SaveManager saveManager;
    public PlayerProgress progress;

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        //SoundManager.instance.PlaySound(gameOverSound);
        FindObjectOfType<SoundManager>().Play("music");
    }
    public void StartGame()
    {
        Debug.Log("start");
        SceneManager.LoadScene(progress.GetNowMap());
        //saveManager.CompleteMap(saveManager.GetProgress());
    }

    public void Restart()
    {
        Debug.Log("restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        Debug.Log("main menu");
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}
