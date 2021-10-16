using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private Animation playerAnim;
    [SerializeField] GameObject player;
    [SerializeField] GameObject portalPrefab;
    [SerializeField] GameObject transitionFXPrefab;
    [SerializeField] GameObject lightTransitionPrefab;
    [SerializeField] GameObject[] interfaceElement;
    private GameObject objPlaceHolder;
    private GameObject transitionObjPlaceHolder;
    private GameObject lightTransitionObjPlaceHolder;

    private bool animIsPlaying;

    
    public void GoToStoreButton()
    {
        Debug.Log(animIsPlaying);
        Vector3 playerPos = player.GetComponent<Transform>().position;
        objPlaceHolder = Instantiate(portalPrefab);
        objPlaceHolder.GetComponent<Transform>().position = new Vector3(playerPos.x + 0.107f, playerPos.y, playerPos.z + 1f);
        animIsPlaying = true;
        StartCoroutine(ErasingInterfaceElements());
    }

    IEnumerator ErasingInterfaceElements()
    {
        for (int i = 0; i < interfaceElement.Length -1; i++)
        {
            interfaceElement[i].SetActive(false);
        }
        float btnAlpha = interfaceElement[3].GetComponent<Image>().color.a;
        float boardAlpha = interfaceElement[4].GetComponent<Image>().color.a;
        btnAlpha = 0f;
        boardAlpha = 0f;
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(StartAnimation());
    }
    IEnumerator StartAnimation()
    {
        yield return new WaitForSeconds(3f);
        Vector3 playerPos = player.GetComponent<Transform>().position;
        transitionObjPlaceHolder = Instantiate(transitionFXPrefab);
        transitionObjPlaceHolder.GetComponent<Transform>().position = new Vector3(playerPos.x + 0.107f, playerPos.y, playerPos.z + 1f);
        lightTransitionObjPlaceHolder = Instantiate(lightTransitionPrefab);
        lightTransitionObjPlaceHolder.GetComponent<Transform>().position = new Vector3(playerPos.x + 0.107f, playerPos.y + 0.204f, playerPos.z + 1f);
        StartCoroutine(LoadStoreScene());
    }

    IEnumerator LoadStoreScene()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < interfaceElement.Length - 1; i++)
        {
            interfaceElement[i].SetActive(true);
        }
        //DestroyImmediate(objPlaceHolder, true);
        Destroy(objPlaceHolder);
        float btnAlpha = interfaceElement[3].GetComponent<Image>().color.a;
        float boardAlpha = interfaceElement[4].GetComponent<Image>().color.a;
        btnAlpha = 255f;
        boardAlpha = 255f;

        SceneManager.LoadScene("Store_Scene");
    }

    private void Update()
    {
        if(animIsPlaying)
        {
            SkipAnimmation();
        }
    }

    private void SkipAnimmation()
    {
        if (Input.GetAxis("Fire1") > 0)
        {
            interfaceElement[5].SetActive(true);
        }
    }

    public void ForceLoadScene()
    {
        StopAllCoroutines();
        for (int i = 0; i < interfaceElement.Length - 1; i++)
        {
            interfaceElement[i].SetActive(true);
        }
        Destroy(objPlaceHolder);
        float btnAlpha = interfaceElement[3].GetComponent<Image>().color.a;
        float boardAlpha = interfaceElement[4].GetComponent<Image>().color.a;
        btnAlpha = 255f;
        boardAlpha = 255f;

        SceneManager.LoadScene("Store_Scene");
    }
}
