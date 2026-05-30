
using System.Collections;
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
    private Collider2D col;

    private enum GameState
    {
        Start,
        Playing,
        Dead 
    }
    private GameState _gameState;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }
    private IEnumerator SimpleTimer()
    {

        Debug.Log("STOP");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isDeath)
        {
            return;
        }
        _isDeath = true;
        col.enabled = false;

        StartCoroutine(SimpleTimer());
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

