using UnityEngine;
using UnityEngine.InputSystem;

public class Bird : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    public void OnJump()
    {
        rb.linearVelocity = new Vector2(0f, jumpForce);
    }
}

