using UnityEngine;

public class Canon : MonoBehaviour
{
    [Header("Canon Parameters")]
    public GameObject projectilePrefab;  // The prefab of the projectile to be shot
    public int numberOfProjectiles = 5;  // Number of projectiles to shoot in one burst
    public float shotForce = 10f;  // The force applied to the projectiles
    public Vector2 shotDirection = Vector2.right;  // Direction in which projectiles are fired (default: right)
    public float fireRate = 1f;  // Frequency of the shots in seconds

    private float timer;  // Timer to track the time between shots
    public bool canFire = false;  // Flag to check if the cannon should start firing

    private void Update()
    {
        // Only update the timer and fire projectiles if the player has triggered the cannon
        if (canFire)
        {
            // Increase the timer based on the time passed since the last frame
            timer += Time.deltaTime;

            // Check if the time between shots has passed
            if (timer >= fireRate)
            {
                // Fire the projectiles when the time is up
                FireProjectiles();

                // Reset the timer to 0 to start counting for the next shot
                timer = 0f;
            }
        }
    }

    private void FireProjectiles()
    {
        // Loop to fire the set number of projectiles
        for (int i = 0; i < numberOfProjectiles; i++)
        {
            // Instantiate a new projectile at the cannon's position
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            // Get the Rigidbody2D component of the projectile
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            // If the Rigidbody2D component exists, apply the shot force in the set direction
            if (rb != null)
            {
                rb.linearVelocity = shotDirection.normalized * shotForce;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        canFire = true;
    }
}
