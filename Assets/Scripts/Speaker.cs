using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Speaker : MonoBehaviour
{

    [SerializeField] private SpeakerSpeech speech;
    private int _messageIndex = 0;
    private string[] _dialogue;
    [SerializeField] private GameObject speechBanner;
    private Canvas _bannerCanvas;
    private TMP_Text _bannerText;
    private Canvas _helpCanvas;
    private InputAction _actionPressed;
    private bool _isBannerOpen;

    void Start()
    {
        _helpCanvas = gameObject.GetComponentInChildren<Canvas>();
        _actionPressed = InputSystem.actions.FindAction("Interact");
        _dialogue = SpeechBanner.GetDialogue(speech);
        _bannerCanvas = speechBanner.GetComponent<Canvas>();
        _bannerText = speechBanner.GetComponentInChildren<TMP_Text>();
    }

    void Update()
    {
        if (_actionPressed.IsPressed() && _helpCanvas.enabled && !_isBannerOpen)
        {
            Debug.Log("This will open the banner..");
            _isBannerOpen = true;
            _bannerCanvas.enabled = true;
            Debug.Log(_dialogue[_messageIndex]);
            _bannerText.text = _dialogue[_messageIndex];
            _messageIndex += 1;
        } else if (_actionPressed.triggered && _helpCanvas.enabled && _isBannerOpen & _messageIndex < _dialogue.Length)
        {
            Debug.Log(_dialogue[_messageIndex]);
            _bannerText.text = _dialogue[_messageIndex];
            _messageIndex += 1;
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
        _bannerCanvas.enabled = false;
        _messageIndex = 0;
    }
}
