using UnityEditorInternal;
using UnityEngine;

public class EnemyDamageDealer : MonoBehaviour
{
    [SerializeField] private int _initialDamageAmount = 5;
    [SerializeField] private float _damageCooldown = 1f;

    private int _currentDamageAmount;
    private float _timeStamp = 0f;


    private void Awake()
    {
        _currentDamageAmount = _initialDamageAmount;
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (Time.time >= _timeStamp)
            {
                collision.collider.GetComponent<Health>().ReduceHealth(_currentDamageAmount);
                _timeStamp = Time.time + _damageCooldown;
            }
        }
    }
}
