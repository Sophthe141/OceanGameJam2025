using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
  public string sceneName;
  
    public void goToScenes()
    {
        PauseSystem.ResumeGame();
        SceneManager.LoadScene(sceneName);
        
    }
}