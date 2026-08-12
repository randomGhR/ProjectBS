using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private int _intialDamageAmount = 10;

    private int _currentDamageAmount;

    private void Awake()
    {
        _currentDamageAmount = _intialDamageAmount;
    }

    public int GetDamageAmount()
    {
        return _currentDamageAmount;
    }
}
