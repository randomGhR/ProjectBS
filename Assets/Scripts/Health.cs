using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private int _intitialHealth = 100;
    [SerializeField] private HealthText _playerHealthUI;
    [SerializeField] private bool _isPlayer = false;
    [SerializeField] private int _score = 100;

    private int _currentHealth;
    private ScoreManager _scoreManager;
    private SpriteManager _spriteManager;



    private void Awake()
    {
        if (_isPlayer)
        {
            _currentHealth = _intitialHealth;
            _spriteManager = GetComponent<SpriteManager>();
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

    private void Update()
    {
        if (_isPlayer && _playerHealthUI != null)
        {
            _playerHealthUI.UpdateHealth(_currentHealth);
        }
    }
    public int GetCurrentHealth()
    {
        return _currentHealth;
    } 

    public void ReduceHealth(int amount)
    {
        _currentHealth -= amount;

        if (_isPlayer)
        {
            _spriteManager.TurnRed();
        }

        if (_currentHealth <= 0)
        {
            if (_isPlayer)
            {
                SceneManager.LoadScene("GameOver");
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
        _spriteManager.TurnGreen();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
