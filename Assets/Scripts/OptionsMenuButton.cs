using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenuButton : MonoBehaviour
{
    [SerializeField] GameObject menuButton;
    private bool menuIsActive = false;
    public void MenuButton()
    {

        if(menuIsActive)
        {
            CloseMenu();
        }
        
        else if(!menuIsActive)
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
}
