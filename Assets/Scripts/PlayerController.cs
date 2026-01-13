
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Transform playerMovePoint;
    private InputAction _movement;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerMovePoint.parent = null; 
        _movement = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerMovePoint.position, speed * Time.deltaTime);
        if (!Mathf.Approximately(Vector3.Distance(transform.position, playerMovePoint.position), 0f)) return;
        if (!_movement.inProgress) return;
        Vector2 direction = _movement.ReadValue<Vector2>();
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            playerMovePoint.position += new Vector3(Mathf.RoundToInt(direction.x), 0f, 0f);
        }
        else
        {
            playerMovePoint.position += new Vector3(0f, Mathf.RoundToInt(direction.y), 0f);
        }
    }
}
