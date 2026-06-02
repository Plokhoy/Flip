using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    public void Update()
    {
        if (GameManager.Instance._gameState == GameManager.GameState.Dead)
        {
            return;
        }
        if (GameManager.Instance._gameState == GameManager.GameState.Playing)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        if (transform.position.x < -10)
        {
            Destroy (gameObject);
        }
    }
}
