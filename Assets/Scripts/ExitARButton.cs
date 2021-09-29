using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitARButton : MonoBehaviour
{
    public void LeavePlanet()
    {
        SceneManager.LoadScene("Galaxy1_Scene");
    }
}
