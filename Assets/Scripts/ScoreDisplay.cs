using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _scoreText;

    void Start()
    {
        _scoreText.text = "SCORE:\n" + ScoreKeeper.Score;        
    }

}
