using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InterfaceButtons : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Galaxy1_Scene");
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("IntroductionScene");
    }

    public void StoreButton()
    {
        SceneManager.LoadScene("Store_Scene");
    }

    public void ReturnToShipButton()
    {
        SceneManager.LoadScene("Galaxy1_Scene");
    }
}

