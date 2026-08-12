using UnityEngine;

[RequireComponent(typeof(Health))]
public class PlayerManager : MonoBehaviour
{
    private Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void Update()
    {
        Debug.Log(health.GetCurrentHealth());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (!other.GetComponent<BulletHitManager>().isSafe)
            {
                health.ReduceHealth(20);
            }
        }
    }
}
