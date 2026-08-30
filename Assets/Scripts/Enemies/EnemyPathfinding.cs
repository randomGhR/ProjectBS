using UnityEngine;
using Pathfinding;

public class EnemyPathfinding : MonoBehaviour
{
    private AIPath _path;
    private Transform _playerTransform;
    [SerializeField] private float _moveSpeed;

    void Awake()
    {
        _path = GetComponent<AIPath>();
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    } 

    private void Update()
    {
        _path.maxSpeed = _moveSpeed;

        _path.destination = _playerTransform.position;        
    }

    
}
