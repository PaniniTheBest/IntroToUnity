using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    [SerializeField] private int endCondition = 0;
    [SerializeField] private int winMenuIndex = 0;

    void Update()
    {
        //When all enemies have been destroyed
        //*MUST be paired with the Array spawner script
        if (gameObject.TryGetComponent<ArraySpawner>(out ArraySpawner arraySpawnerComponent) && endCondition >= arraySpawnerComponent.getSpawnCount())
            SceneManager.LoadScene(winMenuIndex);
    }
    public void LoadSceneIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void ExitGameProgram()
    {
        Application.Quit();
    }
}
