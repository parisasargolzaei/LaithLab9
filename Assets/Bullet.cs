using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab; // The bullet prefab to instantiate
    public Transform bulletSpawn; // The location to spawn the bullet from
    public float bulletSpeed = 30f; // The speed of the bullet
    public float fireRate = 0.5f; // The rate of fire for the player

    private float nextFire; // The time of the next bullet shot

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            ShootBullet();
        }
    }

    // Function to shoot a bullet
    void ShootBullet()
    {
        // Instantiate the bullet prefab at the bullet spawn location
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        // Set the bullet's speed and direction
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }
}
