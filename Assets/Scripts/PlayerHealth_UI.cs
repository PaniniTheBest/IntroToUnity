using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth_UI : MonoBehaviour
{
    private GameObject parentPosistion;
    [SerializeField] public GameObject[] spawnedPrefab; //Object to be spawned
    [SerializeField] private float spawnLocationDistance = 1.5f;// Essentially startingSpawnLocation + spawnLocationDistance for ONLY x position
    [SerializeField] public int spawnCount = 3; //How many prefabs to be spawned

    void Awake()
    {
        parentPosistion = this.gameObject; // Will always refers to the object asigned to this script
    }
    private void Start()
    {
        for (int i = spawnCount; i > 0; i--)
        {
            //To spawn an object
            //Usage of vector3 and not vector2 is due to unity complaining vector2 as an Error
            Instantiate(spawnedPrefab[i], parentPosistion.transform.position + new Vector3(spawnLocationDistance, 0.0f, 0.0f), Quaternion.identity);
        }
    }

    private void Update()
    {
        //Debug.Log for spawn count
        //if(Input.GetKeyDown("x") || Input.GetKeyDown("X"))
        //    getSpawnCount();
    }

    public int eraseHealthBar_UI()
    {
        Debug.Log($"Amount of objects: {spawnCount - 1}");
        return spawnCount--;
    }
    public int getSpawnCount()
    {
        Debug.Log($"Amount of objects: {spawnCount}");
        return spawnCount;
    }
}
