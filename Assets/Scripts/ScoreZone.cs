using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Воёл в оюъект" + collision.gameObject.name);
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Score");
            GameManager.Instance.AddScore();
        }

    }
}
