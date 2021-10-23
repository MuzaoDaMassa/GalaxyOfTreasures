using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class AgeGroupMenu : MonoBehaviour
{
    [SerializeField] GameObject menuObj;

    public void age_sixteen_twentyfour()
    {
        PlayerPrefs.SetInt("TimesPlayed", +1);

        // Create dictionary to store you event data
        Dictionary<string, object> data = new Dictionary<string, object>();
        
        data.Add("Age Groupr", "16 - 24");

        // The name of the event that you will send
        string ageGroup = "16 - 24";

        //Send the event. Also get the result, so we can make sure it sent correctly
        AnalyticsResult result = Analytics.CustomEvent(ageGroup, data);
        Debug.Log(result);

        this.gameObject.SetActive(false);
        menuObj.SetActive(true);

        
    }

    public void age_twentyfive_thirtythree()
    {
        PlayerPrefs.SetInt("TimesPlayed", +1);

        // Create dictionary to store you event data
        Dictionary<string, object> data = new Dictionary<string, object>();

        
        data.Add("Age Group", "25 - 33");

        // The name of the event that you will send
        string ageGroup = "25 - 33";

        //Send the event. Also get the result, so we can make sure it sent correctly
        AnalyticsResult result = Analytics.CustomEvent(ageGroup, data);
        Debug.Log(result);

        this.gameObject.SetActive(false);
        menuObj.SetActive(true);
    }
    public void age_thirtyfour_fortytwoo()
    {
        PlayerPrefs.SetInt("TimesPlayed", +1);

        // Create dictionary to store you event data
        Dictionary<string, object> data = new Dictionary<string, object>();

        data.Add("Age Group", "34 - 42");

        // The name of the event that you will send
        string ageGroup = "34 - 42";

        //Send the event. Also get the result, so we can make sure it sent correctly
        AnalyticsResult result = Analytics.CustomEvent(ageGroup, data);
        Debug.Log(result);

        this.gameObject.SetActive(false);
        menuObj.SetActive(true);
    }
    
    public void age_fortythree()
    {
        PlayerPrefs.SetInt("TimesPlayed", +1);

        // Create dictionary to store you event data
        Dictionary<string, object> data = new Dictionary<string, object>();

        data.Add("Age Groupr", "43 +");

        // The name of the event that you will send
        string ageGroup = "43 +";

        //Send the event. Also get the result, so we can make sure it sent correctly
        AnalyticsResult result = Analytics.CustomEvent(ageGroup, data);
        Debug.Log(result);

        this.gameObject.SetActive(false);
        menuObj.SetActive(true);
    }

    private void Awake()
    {
        Debug.Log(PlayerPrefs.HasKey("TimesPlayed"));
        if (PlayerPrefs.HasKey("TimesPlayed"))
        {
            this.gameObject.SetActive(false);
            menuObj.SetActive(true);
        }
    }

}
