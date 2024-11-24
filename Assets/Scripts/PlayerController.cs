using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D collider;
    float force = 750;
    Vector2 playerInput;
    public enum FacingDirection
    {
        left, right
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        // The input from the player needs to be determined and
        // then passed in the to the MovementUpdate which should
        // manage the actual movement of the character.
        playerInput.x = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        MovementUpdate(playerInput);
    }
    private void MovementUpdate(Vector2 playerInput)
    {
        rb.AddForce(playerInput * force * Time.deltaTime);
    }

    public bool IsWalking()
    {
        if (rb.velocity.magnitude > 0.01f && IsGrounded())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool IsGrounded()
    {
        if (rb.velocity.y > 0.01f || rb.velocity.y < -0.01f)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public FacingDirection GetFacingDirection()
    {
        if (rb.velocity.x < 0)
        {
            return FacingDirection.left;
        }
        else
        {
            return FacingDirection.right;
        }
    }
}
