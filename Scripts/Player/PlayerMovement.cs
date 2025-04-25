using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    public Vector2 moveDir;
    public Vector2 lastMoveDir = Vector2.down;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        // Normalizează doar dacă ambele taste sunt apăsate (evit diagonală mai rapidă)
        moveInput = new Vector2(x, y).normalized;

        // Pentru animații sau direcția ultimei mișcări
        if (moveInput != Vector2.zero)
        {
            lastMoveDir = moveInput;
        }

        moveDir = moveInput; 
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }
}