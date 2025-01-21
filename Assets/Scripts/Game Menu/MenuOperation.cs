using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOperation : MonoBehaviour
{
    [SerializeField] private GameObject optioinMenu;
    [SerializeField] private GameObject controlsMenu;
    [SerializeField] private GameObject creditMenu;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject inventoryMenu;
    [SerializeField] private GameObject videoMenu;
    [SerializeField] private GameObject audioMenu;
    [SerializeField] private GameObject tutorialMenu;
    //private InputManager inputManager;

    // Start is called before the first frame update
    void Start()
    {
        controlsMenu.SetActive(false);
        pauseMenu.SetActive(false);
        inventoryMenu.SetActive(false);
        optioinMenu.SetActive(false);
        creditMenu.SetActive(false);
    }   

    

    public void PauseMenu()
    {
        if(PauseSystem.GameIsPaused){
            
            pauseMenu.SetActive(true);
            optioinMenu.SetActive(false);
            creditMenu.SetActive(false);
            controlsMenu.SetActive(false);
            inventoryMenu.SetActive(false);
            
        }else{
            inventoryMenu.SetActive(false);
            pauseMenu.SetActive(false);
            optioinMenu.SetActive(false);
            creditMenu.SetActive(false);
            controlsMenu.SetActive(false);
        }
    }
    public void OptionMenu()
    {
        optioinMenu.SetActive(true);
        creditMenu.SetActive(false);
        pauseMenu.SetActive(false);
        videoMenu.SetActive(true);
        audioMenu.SetActive(false);
    }

    public void VideoMenu()
    {
        audioMenu.SetActive(false);
        videoMenu.SetActive(true);
    }

    public void AudioMenu()
    {
        videoMenu.SetActive(false);
        audioMenu.SetActive(true);
    }

    public void CreditMenu()
    {
        optioinMenu.SetActive(false);
        creditMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void BackToMenu()
    {
        controlsMenu.SetActive(false);
        optioinMenu.SetActive(false);
        creditMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void ControlsMenu(){
        
        optioinMenu.SetActive(false);
        creditMenu.SetActive(false);
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }
    
    public void InventoryMenu()
    {
            if (InputManager.isInventoryOpen && !PauseSystem.GameIsPaused)
            {
                pauseMenu.SetActive(false);
                inventoryMenu.SetActive(true);
                optioinMenu.SetActive(false);
                creditMenu.SetActive(false); 
            }
            else
            {
               inventoryMenu.SetActive(false);
            }
            
        
    }
}
