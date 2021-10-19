using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditButtons : MonoBehaviour
{
    [SerializeField] GameObject[] dynatonMembers;
    [SerializeField] GameObject creditMainPage, menuHolder;
    [SerializeField] GameObject mainMenu;

    private int n = 0;
    public void ButtonNext()
    {
        if(n == dynatonMembers.Length -1)
        {
            dynatonMembers[n].SetActive(false);
            n = 0;
            dynatonMembers[n].SetActive(true);
        }
        else
        {
            dynatonMembers[n].SetActive(false);
            n++;
            dynatonMembers[n].SetActive(true);
        }
    }


    public void ButtonPrevious()
    {
        if (n == 0)
        {
            dynatonMembers[n].SetActive(false);
            n = dynatonMembers.Length -1;
            dynatonMembers[n].SetActive(true);
        }
        else
        {
            dynatonMembers[n].SetActive(false);
            n--;
            dynatonMembers[n].SetActive(true);
        }
    }

    public void ReturnToMenu()
    {
        dynatonMembers[n].SetActive(false);
        creditMainPage.SetActive(true);
    }

    public void EduardoVassello()
    {
        creditMainPage.SetActive(false);
        n = 0;
        dynatonMembers[n].SetActive(true);
    }
    public void HenriqueDoescher()
    {
        creditMainPage.SetActive(false);
        n = 1;
        dynatonMembers[n].SetActive(true);
    }
    public void JoaoPedroCicala()
    {
        creditMainPage.SetActive(false);
        n = 2;
        dynatonMembers[n].SetActive(true);
    }
    public void MuriloSalviato()
    {
        creditMainPage.SetActive(false);
        n = 3;
        dynatonMembers[n].SetActive(true);
    }
    public void ViniciusScorza()
    {
        creditMainPage.SetActive(false);
        n = 4;
        dynatonMembers[n].SetActive(true);
    }

    public void OpenCreditsMenu()
    {
        mainMenu.SetActive(false);
        menuHolder.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        mainMenu.SetActive(true);
        menuHolder.SetActive(false);  
    }


    /*
     * Código fora de lugar, apenas pra facilitar a vida, pode ser apagado posteriormente
     */

    [SerializeField] GameObject introAnim, skipButton;

    public void SkipAnimation()
    {
        Destroy(skipButton);
        Destroy(introAnim);
    }

    private void Start()
    {
        StartCoroutine(destroySkipAnimButton());
    }

    IEnumerator destroySkipAnimButton()
    {
        yield return new WaitForSeconds(10.15f);
        Destroy(introAnim);
        StopAllCoroutines();
    }
}
