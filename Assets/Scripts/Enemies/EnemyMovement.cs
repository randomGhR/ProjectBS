using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1f;
    
    //[SerializeField] private float _rotationSpeed = 20f;

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

            //RotateTowardsObject(_player);
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

    //Smooth Rotation

    // private void RotateTowardsObject(GameObject target)
    // {
    //     transform.rotation = 
    //     Quaternion.RotateTowards(
    //         transform.rotation, 
    //         CalculateRotationToTarget(target.transform.position), 
    //         _rotationSpeed * Time.deltaTime);
    // }
    // private quaternion CalculateRotationToTarget(Vector2 target)
    // {
    //     Vector2 targetDirection = target - (Vector2) transform.position;
    //     float angle = Vector2.SignedAngle(Vector2.up, targetDirection);
    //     Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);
    //     return targetRotation;
    // }

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
