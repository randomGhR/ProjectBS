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

    public int ReduceHealth(int amount)
    {
        _currentHealth -= amount;
        return _currentHealth;
    }

    public int AddHealth(int amount)
    {
        _currentHealth += amount;
        return _currentHealth;
    }
}
