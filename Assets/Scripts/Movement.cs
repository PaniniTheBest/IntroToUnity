using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 1.0f;

    private void Update()
    {
        float xMovement = Input.GetAxis("Horizontal");
        float yMovement = Input.GetAxis("Vertical");
        //Debug.Log($"x is {xMovement}, y is {yMovement}");
        Vector3 movementVector = new Vector3(xMovement, yMovement, 0);
        transform.position += movementVector * movementSpeed * Time.deltaTime;
    }
//Kept as for future reference
/*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log($"Collision enter with {collision.gameObject.name}");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
       // Debug.Log($"Collision stay with {collision.gameObject.name}");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Debug.Log($"Collision exit with {collision.gameObject.name}");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log($"Trigger enter with {collision.gameObject.name}");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log($"Trigger stay with {collision.gameObject.name}");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log($"Trigger exit with {collision.gameObject.name}");
    }
*/
}
