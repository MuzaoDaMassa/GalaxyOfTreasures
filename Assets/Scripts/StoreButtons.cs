using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreButtons : MonoBehaviour
{
    public GameObject _optionButtons, _inventoryTabs, _commonButtons, _rareButtons, _epicButtons;
    public GameObject _negotiationArea;
    public GameObject _sendCounterOfferButton;
    public GameObject _counterOfferInputField;
    public GameObject _treasure;
    public GreenBartScript _greenBart;
    public UIManager_Store _uiManager;

    public int _counterOffer, _finalPrice;

    public void SellButton()
    {
        _optionButtons.SetActive(false);
        _inventoryTabs.SetActive(true);
        _commonButtons.SetActive(true);
        _rareButtons.SetActive(false);
        _epicButtons.SetActive(false);
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
        //_greenBart._playerOffer = true;
        //_greenBart._negotiationRound++;
        _greenBart._waitingForPlayer = false;
        Debug.Log(_greenBart._counterOfferValue);
    }

    public void AcceptOffer()
    {
        _greenBart._negotiationActive = false;
        _greenBart._negotiationSuccess = true;
        _greenBart._waitingForPlayer = true;
        _uiManager.AddCoins(_greenBart._finalPrice);
        _optionButtons.SetActive(true);
        _negotiationArea.SetActive(false);
        _counterOfferInputField.SetActive(false);
        _sendCounterOfferButton.SetActive(false);
    }
}
