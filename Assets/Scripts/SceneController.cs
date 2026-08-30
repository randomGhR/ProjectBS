using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
