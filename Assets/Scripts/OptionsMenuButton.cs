using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuButton : MonoBehaviour
{
    [SerializeField] GameObject menuButton;
    [SerializeField] GameObject inventoryObject;
    private bool menuIsActive = false;
    private bool inventoryIsActive = false;
    public void MenuButton()
    {

        if(menuIsActive)
        {
            CloseMenu();
        }
        
        else if(!menuIsActive && !inventoryIsActive)
        {
            OpenMenu();
        } 
    }
    public void OpenMenu()
    {
        menuButton.SetActive(true);
        menuIsActive = true;
    }

    public void CloseMenu()
    {
        menuButton.SetActive(false);
        menuIsActive = false;
    }

    public void OpenInventory()
    {
        menuButton.SetActive(false);
        menuIsActive = false;
        inventoryIsActive = true;
        inventoryObject.SetActive(true);
    }

    public void CloseInventory()
    {
        inventoryIsActive = false;
        inventoryObject.SetActive(false);
    }
}
