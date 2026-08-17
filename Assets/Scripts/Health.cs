using UnityEngine;
using UnityEngine.SceneManagement;

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

        if (gameObject.CompareTag("Player"))
        {
            Debug.Log(gameObject + "Health: " + _currentHealth);    
        }

        if (_currentHealth <= 0)
        {
            if (gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene(0);
            }
            Die();
        }
    }

    public void AddHealth(int amount)
    {
        _currentHealth += amount;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
