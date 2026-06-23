using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {

        if (GameManager.Instance._gameState == GameManager.GameState.Dead)
        {
            return;
        }
        if (GameManager.Instance._gameState == GameManager.GameState.Playing)
        {
            rb.MovePosition(rb.position + Vector2.left * moveSpeed * Time.deltaTime);
        }
        if (rb.position.x < -10)

        {
            Destroy (gameObject);
        }
    }
}
