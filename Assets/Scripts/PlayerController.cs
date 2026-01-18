
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask barrier;
    [SerializeField] private float speed = 5f;
    [SerializeField] private Transform playerMovePoint;
    [SerializeField] private Transform playerDirection;
    [SerializeField] private SpriteRenderer playerSpriteRenderer;
    [SerializeField] private LockRelease _lockRelease;
    private SpriteRenderer _targetSpriteRenderer;
    private InputAction _movement;
    private InputAction _swap;
    private bool _isTargeted;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovePoint.parent = null;
        _movement = InputSystem.actions.FindAction("Move");
        _swap = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {

        if (_isTargeted && _swap.triggered)
        {
            SwapSprite(playerSpriteRenderer, _targetSpriteRenderer);
            Debug.Log("Swapping sprite renderer");
        }
        
        transform.position = Vector3.MoveTowards(transform.position, playerMovePoint.position, speed * Time.deltaTime);
        if (!Mathf.Approximately(Vector3.Distance(transform.position, playerMovePoint.position), 0f)) return;
        if (!_movement.inProgress) return;
        Vector2 direction = _movement.ReadValue<Vector2>();
        
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            Vector3 xDirection = new Vector3(Mathf.RoundToInt(direction.x), 0f, 0f);
            if (Physics2D.OverlapCircle(playerMovePoint.position + xDirection, .9f, barrier)) return;
            playerMovePoint.position += xDirection;
            playerDirection.position = transform.position + xDirection;
        }
        else
        {
            Vector3 yDirection = new Vector3(0f, Mathf.RoundToInt(direction.y), 0f);
            if (Physics2D.OverlapCircle(playerMovePoint.position + yDirection, .9f, barrier)) return;
            playerMovePoint.position += yDirection;
            playerDirection.position = transform.position + yDirection;
        }
        
    }

    private void SwapSprite(SpriteRenderer player, SpriteRenderer target)
    {
        (player.sprite, target.sprite) = (target.sprite, player.sprite);
        _lockRelease.CheckLockRelease(target); // swapped so 0 -> 1, or 1 -> 0
    }

    public void SetTargeted(bool value, SpriteRenderer target)
    {
        _isTargeted = value;
        _targetSpriteRenderer = target;
    }
    
}
