
using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    bool _point = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        
        Debug.Log("Воёл в оюъект" + collision.gameObject.name); 
        if (collision.CompareTag("Player") && (_point == false))
        {
            _point = true;
            GameManager.Instance.AddScore();
        }
