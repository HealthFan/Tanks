using UnityEngine;

public class collisionCol : MonoBehaviour
{
    private void HandleCollision(Collision collision)
    {
    Debug.Log("Collision Detected!"); // Add this line
    // Check if the bullet collides with a cube (named "Brick")
    if (collision.gameObject.name == "Brick")
    {
        // Destroy the cube
        Destroy(collision.gameObject);

        // Destroy the bullet
        Destroy(gameObject);
    }
    }
}
