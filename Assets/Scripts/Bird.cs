
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

    private Rigidbody2D rb;
    private Collider2D col;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        col = GetComponent<Collider2D>();
    }
    //private IEnumerator SimpleTimer()
    //{

    //    Debug.Log("STOP");
    //    yield return new WaitForSeconds(3f);
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    //}

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.Instance._gameState == GameManager.GameState.Dead)
        {
            return;
        }
        GameManager.Instance._gameState = GameManager.GameState.Dead;
        GameManager.Instance._gameOverPanel.SetActive(true);
        col.enabled = false;
    }



    public void OnJump()
    {

        if (GameManager.Instance._gameState == GameManager.GameState.Dead)
        {
            return;
        }
        if (GameManager.Instance._gameState == GameManager.GameState.Start)
        {
            GameManager.Instance._gameState = GameManager.GameState.Playing;
            rb.gravityScale = 3;
        }

        rb.linearVelocity = new Vector2(0f, jumpForce);
        transform.rotation = Quaternion.Euler(0, 0, maxTiltUp);
    }

    public void Update()
    {
        if(rb.linearVelocity.y < 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0, maxTiltDown), tiltSpeed * Time.deltaTime);
        }
    }

    
}

