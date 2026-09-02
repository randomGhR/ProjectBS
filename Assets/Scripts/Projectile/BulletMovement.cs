using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 30f;
    [SerializeField] private int _maxBounceCount = 10;
    [SerializeField] private Gradient _bounceColorGradient;

    private Vector2 _velocity;
    private int _collisionLayerMask;
    private float _dt;
    private int _currentBounceCount = 0;

    private SpriteRenderer _spriteRenderer;
    private TrailRenderer _trailRenderer;


    private void Awake()
    {
        _collisionLayerMask = LayerMask.GetMask("Wall", "Obstacle");
        _dt = Time.deltaTime;
        _velocity = transform.right;

        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _trailRenderer = GetComponentInChildren<TrailRenderer>();

        UpdateColor();
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
            AddBounceCount();
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
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, _velocity, _velocity.magnitude, _collisionLayerMask);
        return rayHit;
    }

    private void AddBounceCount()
    {
        _currentBounceCount++;

       UpdateColor();

        if (_currentBounceCount >= _maxBounceCount)
        {
            Destroy(gameObject);
        }
    }

    private void UpdateColor()
    {
        float progress = (float)_currentBounceCount / _maxBounceCount;
        _spriteRenderer.color = _bounceColorGradient.Evaluate(progress);
        _trailRenderer.startColor = _bounceColorGradient.Evaluate(progress);
        _trailRenderer.endColor = _bounceColorGradient.Evaluate(progress);
    }
}
