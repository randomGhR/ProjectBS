using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class HealthText : MonoBehaviour
{
    private TextMeshProUGUI _healthUI;

    private void Awake()
    {
        _healthUI = GetComponent<TextMeshProUGUI>();
    }

    public void ResetHealth(int defaultHealth)
    {
        _healthUI.text = "HP: " + defaultHealth;
    }

    public void UpdateHealth(int newHealth)
    {
        _healthUI.text = "HP: " + newHealth;
    }
}



