using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgeGroupMenu : MonoBehaviour
{
    [SerializeField] GameObject menuObj;

    public void age_sixteen_twentyfour()
    {
        this.gameObject.SetActive(false);
        menuObj.SetActive(true);
    }

    public void age_twentyfive_thirtythree()
    {
        this.gameObject.SetActive(false);
        menuObj.SetActive(true);
    }
    public void age_thirtyfour_fortytwoo()
    {
        this.gameObject.SetActive(false);
        menuObj.SetActive(true);
    }
    
    public void age_fortythree()
    {
        this.gameObject.SetActive(false);
        menuObj.SetActive(true);
    }

}
