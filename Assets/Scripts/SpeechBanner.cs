using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpeechBanner : MonoBehaviour
{

    [SerializeField] private SpeakerSpeech speakerSpeech;

    private InputAction _enterButton;
    private static readonly Dictionary<SpeakerSpeech, string[]> SpeakerSpeeches = new ()
    {
        {SpeakerSpeech.TutorialStage1, new []{ "Hi there, Zero! Welcome to the bottom!", "Try using the W,A,S,D keys to move around!" }},
        {SpeakerSpeech.TutorialStage2, new []{ "You made it up here. Great!", "There's a locked gate up ahead, but you can turn it off by standing on that switch.", "There are also some blocks you can push around. Give it a try!" }},
        {SpeakerSpeech.TutorialStage3, new []{ "You made it past the gate! Awesome!", "There's another locked gate, but you can't move this block.", "Try pressing <space> when the yellow target appears, on the block to the left, to SWAP your value." }},
        {SpeakerSpeech.TutorialStage4, new []{ "Wow! You're fast at this!", "Unfortunately to ascend to the next level, you have to provide \"value\".", "Swap near the teleporter to provide your value." }}
    };


    public static string[] GetDialogue(SpeakerSpeech speech)
    {
        return SpeakerSpeeches[speech];
    }
}

public enum SpeakerSpeech
{
    TutorialStage1,
    TutorialStage2,
    TutorialStage3,
    TutorialStage4,
}