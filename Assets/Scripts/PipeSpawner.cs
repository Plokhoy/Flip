using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject PipePair;
    [SerializeField] private float _timer = 0f;
    private float _minY = -2f;
    private float _maxY = 2f;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (GameManager.Instance._gameState == GameManager.GameState.Dead)
        {
            return;
        }
        if (GameManager.Instance._gameState == GameManager.GameState.Playing)
        {

            if (_timer >= 2.5f)
            {
                Vector3 spawnPos = new Vector3(transform.position.x, Random.Range(_minY, _maxY), transform.position.z);
                Instantiate(PipePair, spawnPos, Quaternion.identity);

                _timer = 0;

            }
        }
  
    }
}
