using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject Pipe;
    [SerializeField] private float _timer = 0f;
    private float _minY = -2f;
    private float _maxY = 2f;

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= 4f)
        {
            new Vector3 (transform.position.x, Random.Range(_minY, _maxY), transform.position.z);
            Instantiate(Pipe, transform.position, Quaternion.identity);
             
            _timer = 0;
        }

        
    }
}
