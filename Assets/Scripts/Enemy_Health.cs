using System.Collections;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealthPoints = 5.0f;
    //[SerializeField]
    private float healthPoints = 5.0f;
    
    [SerializeField]
    private int pointValue = 1;

    [Header ("Damage Indicator")]
    [SerializeField] private float timeInterval_Color = 0.15f;
    [SerializeField] private Color damageColor = Color.red;

    [SerializeField] private EnemyUI_Health healthBarUI;

    private void Awake()
    {
        healthPoints= maxHealthPoints;
        healthBarUI = GetComponentInChildren<EnemyUI_Health>(); 
        healthBarUI.UpdateHealthBar(healthPoints, maxHealthPoints);
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
        {
            healthPoints -= bulletComponent.GetDamageValue();

            StartCoroutine(ColorChangeRed(damageColor,timeInterval_Color)); //Damage Indicator       
            Destroy(bulletComponent.gameObject);
            
            healthBarUI.UpdateHealthBar(healthPoints, maxHealthPoints);

            Debug.Log($"current health of {this.gameObject.name}: {healthPoints}");
        }

        if (healthPoints <= 0)//Death condition        
            ObjectDeath();
       
    }

    private void ObjectDeath()
    {     
        ScoreManager.instance.AddPoint(pointValue);
        ArraySpawner.instance.eraseCount();  
        Destroy(this.gameObject);    
    }
    private IEnumerator ColorChangeRed(Color color, float timeInterval_Color)//Damage Indicator
    {
        gameObject.GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(timeInterval_Color);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
