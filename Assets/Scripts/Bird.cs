using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float tiltSpeed = 5f;
    [SerializeField] private float maxTiltUp = 30f;
    [SerializeField] private float maxTiltDown = -90f;
    private bool _isDeath;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isDeath = true;
       rb.linearVelocity = Vector2.zero;

        
    }

    public void OnJump()
    {

        if (_isDeath)
        {
            return;
        }
        else
        {
            rb.linearVelocity = new Vector2(0f, jumpForce);
            transform.rotation = Quaternion.Euler(0, 0, maxTiltUp);
        }
    }

    public void Update()
    {
        if(rb.linearVelocity.y < 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0, maxTiltDown), tiltSpeed * Time.deltaTime);
        }
    }
}

