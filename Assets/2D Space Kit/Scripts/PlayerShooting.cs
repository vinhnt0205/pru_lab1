using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // For the new Input System

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 50f;
    public Transform gunOffset;
    public float fireRate = 0.5f;          // Delay between shots in seconds

    private bool isFiring;         // Tracks if the fire input is active
    private float lastFireTime = 0f;       // Tracks the last time the player shot
    private bool fireSingle;
    void Update()
    {
        // If firing is active and enough time has passed, shoot
        if((isFiring) || fireSingle)
        {
            if (Time.time >= lastFireTime + fireRate)
            {
                Shoot();
                lastFireTime = Time.time;  // Update the time of the last shot
                fireSingle = false;
            }
            
        }
    }

    public void OnFire(InputValue inputValue)
    {
        isFiring = inputValue.isPressed;
        if (inputValue.isPressed)
        {
            fireSingle = true;
        }   
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, gunOffset.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * bulletSpeed;
        Destroy(bullet, 2f);
    }

}

