using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth_UI : MonoBehaviour
{
    private GameObject parentPosistion;
    [SerializeField] public GameObject[] spawnedPrefab; //Object to be spawned
    [SerializeField] private float spawnLocationDistance_X = 1.5f;// Essentially startingSpawnLocation + spawnLocationDistance_X for ONLY x position
    [SerializeField] public int spawnCount = 0; //How many prefabs to be spawned

    private float maxHP;
    private float currentHP;

    void Awake()
    {
        parentPosistion = this.gameObject; // Will always refers to the object asigned to this script
        spawnCount = spawnedPrefab.Length;
    }
    private void Start()
    {
        for (int i = spawnedPrefab.Length - 1; i > 0; i--)
        {
            //To spawn an object
            //Usage of vector3 and not vector2 is due to unity complaining vector2 as an Error
            Instantiate(spawnedPrefab[i], parentPosistion.transform.position + new Vector3(spawnLocationDistance_X, 0.0f, 0.0f), parentPosistion.transform.rotation);
        }
    }

    private void Update()
    {
        //Debug.Log for spawn count
        if (Input.GetKeyDown("x") || Input.GetKeyDown("X"))
            getSpawnCount();

        this.gameObject.TryGetComponent<Health>(out Health info_HP); //gets HP script
        maxHP = info_HP.GetMaxHP();
        currentHP = info_HP.GetCurrentHP();
    }

    public int eraseHealthBar_UI()
    {
        Debug.Log($"Amount of HP: {spawnCount - 1}");
        return spawnCount--;
    }
    public int getSpawnCount()
    {
        Debug.Log($"Amount of HP: {spawnCount}");
        return spawnCount;
    }
}
