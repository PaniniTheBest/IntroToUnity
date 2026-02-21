using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float maxHealthPoints = 5.0f;
    //[SerializeField]
    private float healthPoints = 5.0f;  
    [SerializeField]
    private int pointValue = 1;
    private int layerNumber = 0;


    [Header ("Damage Indicator")]
    [SerializeField] private float timeInterval_Color = 0.15f;
    [SerializeField] private Color damageColor = Color.red;
    [SerializeField] private SceneLoader sceneloader;

    private void Awake()
    {
        healthPoints= maxHealthPoints;
        layerNumber = this.gameObject.layer;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // We need to make sure that we will only destroy our gameobject
        // If the object we collided with is a Bullet
        /*
        // Method 1: Using tags
        if (collision.gameObject.tag == "Bullet")
        {
            //Destroy the bullet gameObject
            Destroy(collision.gameObject);
            //Destroying our own gameObject
            Destroy(this.gameObject);
        }*/

        // Method 2 (preferred) : Checking for component
        if (collision.gameObject.TryGetComponent<Bullet>(out Bullet bulletComponent))//Condition for getting Damaged         
            HP_Damaged(bulletComponent);
        
        if (healthPoints <= 0)//Death condition        
            ObjectDeath();
    }
    private void HP_Damaged(Bullet bulletComponent)
    {
        healthPoints -= bulletComponent.GetDamageValue();
        StartCoroutine(ColorChange(damageColor, timeInterval_Color)); //Damage Indicator                     
        Destroy(bulletComponent.gameObject);
        Debug.Log($"current health of {this.gameObject.name}: {healthPoints}");
    }

    private void ObjectDeath()
    {
        if (layerNumber == 6)//Enemy Layer
        {
            ScoreManager.instance.AddPoint(pointValue);
            ArraySpawner.instance.eraseCount();
        }
        else if (layerNumber == 7) //Player Layer
        sceneloader.LoadSceneIndex(2);

        Destroy(this.gameObject);    
    }
    private IEnumerator ColorChange(Color color, float timeInterval_Color)//Damage Indicator
    {
        gameObject.GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(timeInterval_Color);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public float GetMaxHP()
    { return maxHealthPoints; }
    public float GetCurrentHP()
    { return healthPoints; }
}
