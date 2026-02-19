using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private int targetSceneLoader;
    
    public void LoadScene()
    {
        SceneManager.LoadScene(targetSceneLoader);
    }
    public void LoadSceneIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
}
