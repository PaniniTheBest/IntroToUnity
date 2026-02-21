using UnityEngine;
using UnityEngine.SceneManagement;

public class WhenAllEnemiesAreDead : MonoBehaviour
{
    //*MUST be paired with the Array spawner script

    [SerializeField] private int endCondition = 0;
    [SerializeField] private int winMenuIndex = 0;
    //private bool winCondition = false;
    void Update()
    {
        gameObject.TryGetComponent<ArraySpawner>(out ArraySpawner arraySpawnerComponent);

        if (endCondition >= arraySpawnerComponent.spawnCount)
        { 
            SceneManager.LoadScene(winMenuIndex);
        }           
    }
    //public bool getBoolWinCon()
    //{ return winCondition; }
}
