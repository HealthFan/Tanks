using UnityEngine;

public class collision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
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
