using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterfaceButtons : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Galaxy1");
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("IntroductionScene");
    }
}
