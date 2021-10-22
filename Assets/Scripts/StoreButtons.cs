using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if ENABLE_CLOUD_SERVICES_ANALYTICS
using UnityEngine.Analytics;
#endif

public class StoreButtons : MonoBehaviour
{
    public GameObject _optionButtons, _inventoryTabs, _commonButtons, _rareButtons, _epicButtons;
    public GameObject _negotiationArea;
    public GameObject _sendCounterOfferButton;
    public GameObject _counterOfferInputField;
    public GameObject _treasure;
    public GameObject _returnToShipObj;
    public GameObject _cancelPreTrade;
    public GreenBartScript _greenBart;
    public UIManager_Store _uiManager;

    public int _counterOffer, _finalPrice;
    public static int _profit;

    public void SellButton()
    {
        _optionButtons.SetActive(false);
        _inventoryTabs.SetActive(true);
        _commonButtons.SetActive(true);
        _rareButtons.SetActive(false);
        _epicButtons.SetActive(false);
        _returnToShipObj.SetActive(false);
        _cancelPreTrade.SetActive(true);
    }

    public void CommonTabButton()
    {
        _commonButtons.SetActive(true);
        _rareButtons.SetActive(false);
        _epicButtons.SetActive(false);
        
    }

    public void RareTabButton()
    {
        _commonButtons.SetActive(false);
        _rareButtons.SetActive(true);
        _epicButtons.SetActive(false);
    }

    public void EpicTabButton()
    {
        _commonButtons.SetActive(false);
        _rareButtons.SetActive(false);
        _epicButtons.SetActive(true);
    }

    public void CommonButton1()
    {
        _treasure = _uiManager._commonTreasures[0];
        _negotiationArea.SetActive(true);
        _greenBart._negotiationStarted = true;
        _inventoryTabs.SetActive(false);
        _commonButtons.SetActive(false);
        Debug.Log(_treasure);
    }

    public void CancelTradeButton()
    {
        _optionButtons.SetActive(true);
        _negotiationArea.SetActive(false);
        _counterOfferInputField.SetActive(false);
        _sendCounterOfferButton.SetActive(false);
        _greenBart._negotiationActive = false;
        _greenBart._negotiationSuccess = false;
        _greenBart._waitingForPlayer = false;
        _returnToShipObj.SetActive(true);
    }

    public void CounterOfferButton()
    {
        _counterOfferInputField.SetActive(true);
        _sendCounterOfferButton.SetActive(true);
        _greenBart._negotiationActive = true;


    }

    public void SendCounterOffer()
    {
        var _tempCounterOffer = _counterOfferInputField.GetComponentInChildren<GetCounterOfferScript>()._counterOffer;
        _greenBart._counterOfferValue = _tempCounterOffer;
        _greenBart._waitingForPlayer = false;

        Debug.Log(_greenBart._counterOfferValue);

        // Create dictionary to store you event data
        Dictionary<string, object> data = new Dictionary<string, object>();

        //Add the counter offer to your event data
        data.Add("Counter Offer", _tempCounterOffer);

        // The name of the event that you will send
        string counterOffers = "" + _tempCounterOffer;

        //Send the event. Also get the result, so we can make sure it sent correctly
        AnalyticsResult result = Analytics.CustomEvent(counterOffers, data);
        Debug.Log(result);
    }

    public void AcceptOffer()
    {
        _greenBart._negotiationActive = false;
        _greenBart._negotiationSuccess = true;
        _greenBart._waitingForPlayer = true;
        _greenBart._greenBartImage.sprite = _greenBart._greenBartHappy;
        _uiManager.AddCoins(_greenBart._finalPrice);
        _optionButtons.SetActive(true);
        _returnToShipObj.SetActive(true);
        _negotiationArea.SetActive(false);
        _counterOfferInputField.SetActive(false);
        _sendCounterOfferButton.SetActive(false);
        _profit = _greenBart._finalPrice - _greenBart._originalPrice;

        // Create dictionary to store you event data
        Dictionary<string, object> data = new Dictionary<string, object>();

        //Add the counter offer to your event data
        data.Add("Counter Offer", _profit);

        // The name of the event that you will send
        string profit = "" + _profit;

        //Send the event. Also get the result, so we can make sure it sent correctly
        AnalyticsResult result = Analytics.CustomEvent(profit, data);
        Debug.Log(result);

    }

    public void CancelPreTrade()
    {
        _optionButtons.SetActive(true);
        _inventoryTabs.SetActive(false);
        _commonButtons.SetActive(false);
        _rareButtons.SetActive(false);
        _epicButtons.SetActive(false);
        _returnToShipObj.SetActive(true);
        _cancelPreTrade.SetActive(false);
    }
}
