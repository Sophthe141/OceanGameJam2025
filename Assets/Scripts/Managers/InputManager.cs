using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public  bool isInteracting;
    public static bool isInventoryOpen = false;
    public static InputManager instance{get; private set;}
    public bool vehicleInAction;
    public bool isNextDialogue;

    public bool isUsingPower = false;
    // Start is called before the first frame update
    

    public void FixedsetAction(InputAction.CallbackContext value)
    {
        if (!PauseSystem.GameIsPaused)
        {
            if (value.phase == InputActionPhase.Performed)
            {
                isInteracting = true;
            }
            if (value.phase == InputActionPhase.Canceled)
            {
                isInteracting = false;
            }
        }
    }

    public void FixedsetSecondaryAction(InputAction.CallbackContext value)
    {
        if(!PauseSystem.GameIsPaused){
        if (value.phase == InputActionPhase.Performed)
        {
            vehicleInAction = true;

        }
        if (value.phase == InputActionPhase.Canceled)
        {
            vehicleInAction = false;

        }
        }
    }

    public void UsePower(InputAction.CallbackContext value)
    {
        if(!PauseSystem.GameIsPaused){
        if (value.phase == InputActionPhase.Performed)
        {
            isUsingPower = true;
        }
        if (value.phase == InputActionPhase.Canceled)
        {
            isUsingPower = false;
        }
        }
    }
    
    public void nextDialogue(InputAction.CallbackContext value)
    {
        if(!PauseSystem.GameIsPaused){
        if (value.phase == InputActionPhase.Performed)
        {
            isNextDialogue = true;
        }
        else if (value.phase == InputActionPhase.Canceled)
        {
            isNextDialogue = false;
        }
        }
    }

    public void CallPauseMenu(InputAction.CallbackContext value)
    {
        if (value.phase == InputActionPhase.Performed)
        {
            if (PauseSystem.GameIsPaused)
            {
                PauseSystem.ResumeGame();
            }
            else
            {
                PauseSystem.PauseGame();
            }
        }

    }


    
    public void CallInventory(InputAction.CallbackContext value)
    {
        if (value.phase == InputActionPhase.Performed)
        {
            if (isInventoryOpen)
            {
                isInventoryOpen = false;
            }
            else
            {
                isInventoryOpen = true;
            }
        }
       

    }

}
