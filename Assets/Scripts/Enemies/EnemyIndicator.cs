using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyIndicator : MonoBehaviour
{
    //seconds
    [SerializeField] private float _duration = 2f;

    private float _timeStamp;
    
    private void Awake()
    {
        _timeStamp = Time.time + Mathf.Infinity;
    }

    private void Update()
    {
        if (_timeStamp <= Time.time)
        {
            Destroy(gameObject);
        }
    }

    void OnBecameVisible()
    {
        _timeStamp = Time.time + _duration;
    }
}
