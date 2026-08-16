using System.Security.Cryptography;
using UnityEditor.Callbacks;
using UnityEditor.VisionOS;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1f;

    private Rigidbody2D rb;
    private GameObject _player;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    } 

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (_player != null)
        {
            LookAtObject(_player);
        }
    }

    private void FixedUpdate()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        rb.linearVelocity = transform.up * _moveSpeed;
    }

    private void LookAtObject(GameObject target)
    {
        transform.up = CalculateDirection(target.transform.position);
    }

    private Vector2 CalculateDirection(Vector3 target)
    {
        Vector2 direction = target - transform.position;
        return direction.normalized;
    }
}
