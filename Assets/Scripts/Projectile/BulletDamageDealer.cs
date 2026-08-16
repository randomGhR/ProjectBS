using UnityEngine;

public class BulletDamageDealer : MonoBehaviour
{
    [SerializeField] private int _intialDamageAmount = 10;

    private int _currentDamageAmount;

    private void Awake()
    {
        _currentDamageAmount = _intialDamageAmount;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Health>(out var health))
        {
            health.ReduceHealth(_currentDamageAmount);
        }
    }
}
