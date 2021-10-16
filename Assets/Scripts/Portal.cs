using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public GameObject player;
    private Animation playerAnim;
    public GameObject portalPrefab;
    public GameObject[] interfaceElement;
    private GameObject objPlaceHolder;

    
    public void StoreButton()
    {
        Vector3 playerPos = player.GetComponent<Transform>().position;
        objPlaceHolder = Instantiate(portalPrefab);
        objPlaceHolder.GetComponent<Transform>().position = new Vector3(playerPos.x + 0.107f, playerPos.y, playerPos.z + 1f);
        StartCoroutine(WaitToStartAnim());
    }

    IEnumerator WaitToStartAnim()
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
        PlayerAnimation();
    }
    private void PlayerAnimation()
    {
        

        StartCoroutine(LoadStoreScene());
    }

    IEnumerator LoadStoreScene()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < interfaceElement.Length - 1; i++)
        {
            interfaceElement[i].SetActive(true);
        }
        DestroyImmediate(objPlaceHolder, true);
        float btnAlpha = interfaceElement[3].GetComponent<Image>().color.a;
        float boardAlpha = interfaceElement[4].GetComponent<Image>().color.a;
        btnAlpha = 255f;
        boardAlpha = 255f;
        SceneManager.LoadScene("Store_Scene");
    }

    public void SkipAnimation()
    {

    }

    
    
}
