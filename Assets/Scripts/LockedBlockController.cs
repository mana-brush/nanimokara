using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class LockedBlockController : MonoBehaviour
{

    [SerializeField] private SpriteRenderer lockedBlockSpriteRenderer;
    [SerializeField] private PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerController.SetTargeted(true, lockedBlockSpriteRenderer);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerController.SetTargeted(false, lockedBlockSpriteRenderer);
    }
}
