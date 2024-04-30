using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player movement

    private Rigidbody2D rb; // Reference to the Rigidbody2D component

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }

    // Update is called once per frame
    void Update()
    {
        // Read input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector2 movementDirection = new Vector2(horizontalInput, verticalInput).normalized;

        // Move the player
        rb.velocity = movementDirection * moveSpeed;

        // Rotate player to face the movement direction
        if (movementDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(movementDirection.y, movementDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
