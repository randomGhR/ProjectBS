using UnityEngine;

[CreateAssetMenu(fileName = "LiveObjectDataSO", menuName = "Scriptable Objects/LiveObjectDataSO")]
public class LiveObjectDataSO : ScriptableObject
{
    public enum ObjectType
    {
        Player,
        Enemy,
        Bullet
    }

    [SerializeField] private int _health;
    [SerializeField] private int _damageAmount;
    [SerializeField] private ObjectType _type;

    public int MaxHealth => _health;
    public int Damage => _damageAmount;

    public ObjectType Type => _type;
}
