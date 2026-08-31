using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SpriteManager))]
public class Health : MonoBehaviour
{
    [SerializeField] private int _intitialHealth = 100;
    [SerializeField] private HealthText _playerHealthUI;
    [SerializeField] private bool _isPlayer = false;
    [SerializeField] private int _score = 100;

    private int _currentHealth;
    private ScoreManager _scoreManager;



    private void Awake()
    {
        if (_isPlayer)
        {
            _currentHealth = _intitialHealth;
        }
    }
    private void Start()
    {
        _scoreManager = FindFirstObjectByType<ScoreManager>();

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
                SceneManager.LoadScene("MainMenu");
            }
            else
            {
                _scoreManager.AddScore(_score);
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
