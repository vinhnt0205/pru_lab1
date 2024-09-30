using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour
{
    [SerializeField]
    private float tumble;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        // Generate a random angle for rotation
        float randomAngle = Random.Range(0f, 360f); // Random angle in degrees
        float radians = randomAngle * Mathf.Deg2Rad; // Convert to radians

        // Set the angular velocity to rotate around the z-axis
        rb.angularVelocity = new Vector3(0, 0, tumble); // Ensure z-axis rotation
    }
}