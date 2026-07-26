using UnityEditor;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 30f;

    private Vector2 _velocity;
    private int _wallLayerMask;
    private float _dt;

    private void Awake()
    {
        _wallLayerMask = LayerMask.GetMask("Wall");
        _dt = Time.deltaTime;
        _velocity = transform.right;
    }

    private void Update()
    {  
        _dt = Time.deltaTime;

        MoveBullet();
    }

    private void MoveBullet()
    {
        _velocity = _velocity.normalized * _speed * _dt;

        RaycastHit2D collision = GetRaycastForCollision();
        if (collision)
        {
            _velocity = Vector2.Reflect(_velocity, collision.normal);
            transform.right = _velocity;
        }
        else
        {
            transform.position += (Vector3) _velocity;
        }
    }

    private RaycastHit2D GetRaycastForCollision()
    {
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, _velocity, _velocity.magnitude, _wallLayerMask);
        return rayHit;
    }


}
