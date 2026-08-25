using System.Collections;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private float _redDuration = 0.5f;

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void TurnRed()
    {
        StartCoroutine(RedCoroutine());
    }

    private IEnumerator RedCoroutine()
    {
        _spriteRenderer.color = Color.red;

        yield return new WaitForSeconds(_redDuration);

        _spriteRenderer.color = Color.white;
    }
}
