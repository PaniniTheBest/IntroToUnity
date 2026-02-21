using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSceneIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void ExitGameProgram()
    {
        Application.Quit();
    }
}
