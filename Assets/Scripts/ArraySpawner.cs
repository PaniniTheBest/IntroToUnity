using System;
using Unity.VisualScripting;
using UnityEngine;

public class ArraySpawner : MonoBehaviour
{
    private GameObject parentPosistion;
    [SerializeField] public GameObject[] spawnedPrefab; //Object to be spawned
    [SerializeField] private float spawnLocationDistance = 1.5f;// Essentially startingSpawnLocation + spawnLocationDistance for ONLY x position
    [SerializeField] public int spawnCount = 3; //How many prefabs to be spawned
    public static ArraySpawner instance;
    void Awake()
    {
        instance = this;
        parentPosistion = this.gameObject; // Will always refers to the object asigned to this script
    }
    private void Start()
    {
        for (int i = spawnCount - 1; i > -1; i--)
        {
            Instantiate(spawnedPrefab[i], parentPosistion.transform.position += new Vector3(spawnLocationDistance, 0.0f, 0.0f), Quaternion.identity);
            //spawnedPrefab[i].transform.parent = parentPosistion.transform ;
        }
    }
    public int eraseCount()
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
