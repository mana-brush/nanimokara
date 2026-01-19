using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class LockRelease : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private TilemapRenderer tilemapRenderer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        TriggerLockRelease(other.gameObject, false);
    }    
    
    private void OnTriggerExit2D(Collider2D other)
    {
        TriggerLockRelease(other.gameObject, true);
    }

    private void TriggerLockRelease(GameObject triggeredGameObject, bool isEnabled)
    {
        if (!triggeredGameObject.GetComponentsInChildren<SpriteRenderer>().Any(sprite => sprite.sprite.name.Equals("Sprite-0000"))) return;
        rb.GetComponent<Collider2D>().enabled = isEnabled;
        tilemapRenderer.enabled = isEnabled;
    }

    public void CheckLockRelease(SpriteRenderer targetSpriteRenderer)
    {
        if (!targetSpriteRenderer.sprite.name.Equals("Sprite-0000"))
        {
            rb.GetComponent<Collider2D>().enabled = true;
            tilemapRenderer.enabled = true;
        }
        else
        {
            rb.GetComponent<Collider2D>().enabled = false;
            tilemapRenderer.enabled = false;
        }
    }
}
