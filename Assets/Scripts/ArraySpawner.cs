using System;
using Unity.VisualScripting;
using UnityEngine;

public class ArraySpawner : MonoBehaviour
{
    private GameObject parentPosistion;
    [SerializeField] public GameObject[] spawnedPrefab; //Object to be spawned
    [SerializeField] private float spawnLocationDistance = 1.5f;// Essentially startingSpawnLocation + spawnLocationDistance for ONLY x position
    private int spawnCount = 0; //How many prefabs had spawned
    public static ArraySpawner instance;

    void Awake()
    {
        instance = this;
        parentPosistion = this.gameObject; // Will always refers to the object asigned to this script
        spawnCount = spawnedPrefab.Length;
    }
    private void Start()
    {
        for (int i = spawnedPrefab.Length - 1; i > -1; i--)
        {
            //To spawn an object
            //Usage of vector3 and not vector2 is due to unity complaining vector2 as an Error

            Instantiate(spawnedPrefab[i], parentPosistion.transform.position += new Vector3(spawnLocationDistance, 0.0f, 0.0f), parentPosistion.transform.rotation);
            spawnedPrefab[i].name = $"Bad Fella {i}";
            spawnedPrefab[i].transform.parent = parentPosistion.transform;

            /* Experimental code to make prefabs into a child {DOES NOT WORK}
              game will work, the errors are just ugly looking during debug
                                     \/  \/  \/  \/
            */
            //parentPosistion.instance.transform.SetParent(spawnedPrefab[i].transform);         
            //parentPosistion.transform.SetParent(spawnedPrefab[i].transform , false);
        }
    }
    public int eraseCount()
    {
        Debug.Log($"Amount of objects: {spawnCount - 1}");
        return spawnCount--;      
    }
    public int getSpawnCount()
    {
        //Debug.Log($"Amount of objects: {spawnCount}");
        return spawnCount; 
    }
}
