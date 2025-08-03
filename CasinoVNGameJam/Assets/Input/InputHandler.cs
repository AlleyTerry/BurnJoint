using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class InputHandler : MonoBehaviour
{
    private Camera mainCamera;
    public DialogueRunner dialogueRunner;
    public string objectname;
    //find lockminigame script
    public GameObject lockMinigame;
    [SerializeField] private AudioClip[] clicksSFX;
    
     private void Awake()
    {
        mainCamera = Camera.main;
        //disable number input by default
        PlayerInput playerInput = GetComponent<PlayerInput>();
        playerInput.actions.FindActionMap("LockMinigame").Disable();

    }

    public void onClick(InputAction.CallbackContext context)
    {
        //only fires when the player clicks
        if (!context.started)
        {
            return;
        }
        
        //get the mouse position in world space
        var rayHit = Physics2D.GetRayIntersection(mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        
        //check if the ray hit something if not return and do nothing
        if(!rayHit.collider)
        {
            return;
        }
        
        //get the name of the object that was clicked
        objectname = rayHit.collider.gameObject.name;
        Debug.Log("Clicked on: " + objectname);
        DialogueStarted();
    }
    
    
    public void NumbersInput(InputAction.CallbackContext context)
    {
        //only fires when the player presses a number
        if (!context.started)
        {
            return;
        }
        //read the input when the player presses a number
        SoundEffectsManager.instance.PlayRandomSoundEffectClip(clicksSFX, transform, 1f);
        string input = context.action.name;
        Debug.Log("Input received: " + input);
        lockMinigame.GetComponent<LockMinigame>().OnNumberInput(input);


    }
    
    public void DialogueStarted()
    {
        //start dialogue when clicked
        if (!dialogueRunner.IsDialogueRunning)
        {
            //play click sfx
            SoundEffectsManager.instance.PlayRandomSoundEffectClip(clicksSFX, transform, 1f);
            dialogueRunner.StartDialogue(objectname);
            PlayerInput playerInput = GetComponent<PlayerInput>();
            playerInput.actions.FindActionMap("Gameplay").Disable();
        }
    }
    [YarnCommand("OnDialogueEnd")]
    //when dialogue ends, enable input
    public void OnDialogueEnd()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();
        playerInput.actions.FindActionMap("Gameplay").Enable();
    }
    
    
    /*[YarnCommand("OnDialogueEnd")]
    public void OnDialogueEnd()
    {
        //when dialogue ends, enable input
        PlayerInput playerInput = GetComponent<PlayerInput>();
        playerInput.actions.FindAction("Click").Enable();
    }*/
}
