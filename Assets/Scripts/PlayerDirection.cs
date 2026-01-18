
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _spriteRenderer.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _spriteRenderer.enabled = false;
    }
}
