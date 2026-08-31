using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreText;

    public int _score {get; private set;}

    private void Awake()
    {
        _score = 0;
    }

    private void Update()
    {
        _scoreText.text = "SCORE: " + _score;
    }

    public void AddScore(int amount)
    {
        _score += amount;
    }
}
