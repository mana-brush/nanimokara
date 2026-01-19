using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Speaker : MonoBehaviour
{

    private Canvas _helpCanvas;
    private InputAction _actionPressed;
    private bool _isBannerOpen;

    void Start()
    {
        _helpCanvas = gameObject.GetComponentInChildren<Canvas>();
        _actionPressed = InputSystem.actions.FindAction("Interact");
    }

    void Update()
    {
        if (_actionPressed.IsPressed() && _helpCanvas.enabled && !_isBannerOpen)
        {
            Debug.Log("This will open the menu.");
            _isBannerOpen = true;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        _helpCanvas.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _helpCanvas.enabled = false;
        _isBannerOpen = false;
    }
}
