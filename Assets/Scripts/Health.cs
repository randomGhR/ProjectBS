using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _intitialHealth = 100;

    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = _intitialHealth;
    }

    public int GetCurrentHealth()
    {
        return _currentHealth;
    } 

    public void ReduceHealth(int amount)
    {
        _currentHealth -= amount;
    }

    public void AddHealth(int amount)
    {
        _currentHealth += amount;
    }
}
