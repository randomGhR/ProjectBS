using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private float _spawnRate = 0.2f;
    [SerializeField] private float _spawnRateVariance = 0.2f;
    [SerializeField] private float _startDelay = 0f;

    private float _timer = 0f;

    private void Start()
    {
        _timer = _startDelay;
    }

    private void Update()
    {
        if (_timer > 0f)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            SpawnEnemy();
            ResetTimer();
        }
        
    }

    private void ResetTimer()
    {
        _timer = 1f / (_spawnRate + Random.Range(-_spawnRateVariance, _spawnRateVariance));
    }

    private void SpawnEnemy()
    {
        Instantiate(
            original: _enemyPrefabs[Random.Range(0, _enemyPrefabs.Length)], 
            position: transform.position,
            rotation: Quaternion.identity);
        
    }    
}