using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetCollidersScript : MonoBehaviour
{
    private PlayerController playerController;

    public GameObject sceneTransitionText;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerController._inPlanetOrbit = true;
            StartCoroutine(ChangeSceneRoutine());
        }
    }

    IEnumerator ChangeSceneRoutine()
    {
        sceneTransitionText.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("TreasureHuntScene");
    }
}
