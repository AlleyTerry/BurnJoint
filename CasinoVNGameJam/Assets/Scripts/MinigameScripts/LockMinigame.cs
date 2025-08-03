using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Yarn.Unity;

public class LockMinigame : MonoBehaviour
{
    public string lockCode = "1234"; // The correct code for the lock
    private string playerInput = ""; // The player's input code
    private string currentNum;
  


    private void Update()
    {
        
    }

    [YarnCommand("ChangeObject")]
    public void ChangeObject()
    {
        InputHandler inputHandler = FindObjectOfType<InputHandler>();
        inputHandler.lockMinigame = this.gameObject; // Set the lockMinigame reference in InputHandler
    }
    public void EnableInput()
    {
        PlayerInput playerInput = FindObjectOfType<PlayerInput>();
        playerInput.actions.FindActionMap("LockMinigame").Enable(); // Enable the LockMinigame action map
        playerInput.actions.FindActionMap("Gameplay").Disable(); // Disable clicking
        
    }
    public void DisableInput()
    {
        PlayerInput playerInput = FindObjectOfType<PlayerInput>();
        playerInput.actions.FindActionMap("LockMinigame").Disable(); // Disable the LockMinigame action map
        //playerInput.actions.FindActionMap("Gameplay").Enable(); // Enable clicking
    }

    [YarnCommand("StartLockMinigame")]
    public void StartLockMinigame()
    {
        EnableInput(); // Enable input for the minigame
        playerInput = ""; // Reset the player's input
        Debug.Log("Lock minigame started. Enter the code.");
    }
    
    public void OnNumberInput(string number)
    {
        Debug.Log(number + " pressed.");
        

        playerInput += number; // Append the input number to the player's input
        Debug.Log("Player input: " + playerInput);

        if (playerInput.Length == lockCode.Length)
        {
            CheckCode();
        }
    }

    public void CheckCode()
    {
        DisableInput();
        // Check if the player's input matches the lock code
        if (playerInput == lockCode)
        {
            Debug.Log("Lock opened successfully!");
            //play good ending dialogue
            DialogueRunner dialogueRunner = FindObjectOfType<DialogueRunner>();
            if (gameObject.name == "DoorLock")
            {
                dialogueRunner.StartDialogue("BadEnd"); // Start the good ending dialogue
            }
            else if (gameObject.name == "WindowLock")
            {
                dialogueRunner.StartDialogue("GoodEnd"); // Start the good ending dialogue
            }
          
        }
        else
        {
            Debug.Log("Incorrect code. Try again.");
            DialogueRunner dialogueRunner = FindObjectOfType<DialogueRunner>();
            dialogueRunner.StartDialogue("WrongCode"); // Start the wrong code dialogue
            PlayerInput playerInput = FindObjectOfType<PlayerInput>();
            playerInput.actions.FindActionMap("Gameplay").Enable();
        }
    }
}
