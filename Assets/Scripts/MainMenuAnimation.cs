using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnimation : MonoBehaviour
{
    [SerializeField] GameObject introObject;
    void Start()
    {
        StartCoroutine(DestroyIntroduction());   
    }

    IEnumerator DestroyIntroduction()
    {
        yield return new WaitForSeconds(10.15f);
        introObject.SetActive(false);
    }

    private void Update()
    {
        if(introObject.gameObject == null)
        {
            StopAllCoroutines();
        }
    }

}
