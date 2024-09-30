using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;  // Speed of the asteroid

    public GameObject enemyPrefab;
    public float minInstantiateValue;
    public float maxInstantiateValue;
    public float destroyTime = 30f;

    void Start()
    {
        // Randomize the direction of movement
    }

    void Update()
    {
        // Move the asteroid
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name); // Log the name of the colliding object

        // Check if the object that hit the asteroid is tagged as "Bullet"
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Asteroid hit by bullet!"); // Log when the asteroid is hit
            Destroy(gameObject);  // Destroy the asteroid
            Destroy(collision.gameObject);  // Destroy the bullet
        }

    }

    

}


