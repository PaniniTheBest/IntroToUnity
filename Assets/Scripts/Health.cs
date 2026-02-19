using System.Collections;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int healthPoints = 5;
    [SerializeField]
    private int pointValue = 1;
    [Header ("Damage Indicator")]
    [SerializeField] private float timeInterval_Color = 0.15f;
    [SerializeField] private Color damageColor = Color.red;

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

            StartCoroutine(ColorChangeRed(damageColor,timeInterval_Color));//Damage Indicator

            Destroy(bulletComponent.gameObject);
            Debug.Log($"current health of {this.gameObject.name}: {healthPoints}");
        }

        if (healthPoints <= 0)//Death condition
        {
            ObjectDeath();
        }
    }

    private void ObjectDeath()
    {
        Destroy(this.gameObject);

        if (this.gameObject.layer == 6)//Enemy Points
            ScoreManager.instance.AddPoint(pointValue);

        if(this.gameObject.layer == 7)//Player Gameover Screen
            SceneManager.LoadScene(2);
        
    }

    private IEnumerator ColorChangeRed(Color color, float timeInterval_Color)
    {
        gameObject.GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(timeInterval_Color);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;

    }
}
