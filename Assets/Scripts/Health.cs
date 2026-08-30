using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SpriteManager))]
public class Health : MonoBehaviour
{
    [SerializeField] private int _intitialHealth = 100;
    [SerializeField] private HealthText _playerHealthUI;

    private int _currentHealth;

    [SerializeField] private bool _isPlayer = false;

    private void Awake()
    {
        if (_isPlayer)
        {
            _currentHealth = _intitialHealth;
        }
    }
    private void Start()
    {
        if (_isPlayer && _playerHealthUI != null)
        {
            _playerHealthUI.ResetHealth(_intitialHealth);
            
        }
    }


    public int GetCurrentHealth()
    {
        return _currentHealth;
    } 

    public void ReduceHealth(int amount)
    {
        _currentHealth -= amount;

        if (_isPlayer && _playerHealthUI != null)
        {
            GetComponent<SpriteManager>().TurnRed();

            _playerHealthUI.UpdateHealth(_currentHealth);
        }

        if (_currentHealth <= 0)
        {
            if (_isPlayer)
            {
                SceneManager.LoadScene("GameScene");
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
