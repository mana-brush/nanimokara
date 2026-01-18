using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private const int MainGame = 1;
    
    public void StartGame()
    {
        SceneManager.LoadScene(MainGame);
    }
    
}
