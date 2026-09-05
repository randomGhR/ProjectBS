using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreText;

    public int _score {get; private set;}

    [Header("Health Reward Setup")]
    [SerializeField] private Health _playerHealth;
    [SerializeField] private int _rewardAmount = 20;
    [SerializeField] private int _rewardInterval = 10000;

    private int _rewardCounter;

    private void Awake()
    {
        _score = 0;
    }

    private void Update()
    {
        _scoreText.text = "SCORE: " + _score;
        ScoreKeeper.Score = _score;
    }

    public void AddScore(int amount)
    {
        _score += amount;
        _rewardCounter += amount;
        if (_rewardCounter >= _rewardInterval)
        {
            _playerHealth.AddHealth(_rewardAmount);
            _rewardCounter = 0;
        }
    }
}
