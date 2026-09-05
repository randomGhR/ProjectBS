using System.Collections;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private float _redDuration = 0.5f;
    [SerializeField] private float _greenDuration = 0.8f;

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void TurnRed()
    {
        StartCoroutine(ChangeColorCoroutine(Color.red, _redDuration));
    }

    public void TurnGreen()
    {
        StartCoroutine(ChangeColorCoroutine(Color.green, _greenDuration));
    }

    private IEnumerator ChangeColorCoroutine(Color color, float duration)
    {
        _spriteRenderer.color = color;

        yield return new WaitForSeconds(duration);

        _spriteRenderer.color = Color.white;
    }
}
