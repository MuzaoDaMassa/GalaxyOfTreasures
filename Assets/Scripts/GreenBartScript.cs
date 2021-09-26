using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBartScript : MonoBehaviour
{
    public int _offerValue;
    public int _counterOfferValue;
    public int _finalPrice;
    public int _negotiationRound = 1;
    public int _maxRounds;
    //public bool _playerOffer;
    public bool _negotiationStarted = false;
    public bool _waitingForPlayer = false;
    public bool _negotiationActive, _negotiationSuccess = false;
    public GameObject _negotiationArea;
    public GameObject _acceptOfferButton, _counterOfferButton, _cancelTradeButton;
    public GameObject[] _commonButtons;
    public UIManager_Store _uiManager;


    private int _originalPrice;
    private GameObject _activeTreasure;

    // Update is called once per frame
    void Update()
    {
        if (_negotiationStarted)
        {
            _negotiationStarted = false;
            StartCoroutine(NegotiationRoutine());
        }
    }

    IEnumerator NegotiationRoutine()
    {
        //_waitingForPlayer = true;
        yield return new WaitForSeconds(1f);

        _activeTreasure = _commonButtons[0].GetComponent<StoreButtons>()._treasure;
        _originalPrice = _activeTreasure.GetComponent<TreasureScript>()._treasurePrice;
        _maxRounds = Random.Range(2, 5);


        do
        {
            _waitingForPlayer = true;
            NegotiationPrice();
            yield return new WaitUntil(() => _waitingForPlayer == false);

        } while (_negotiationActive);
 

    }


    public void NegotiationPrice()
    {
        if (_negotiationRound == 1)
        {
            _negotiationRound++;
            _offerValue = _originalPrice;
            _finalPrice = _offerValue;
            Debug.Log("That's a nice Item! I'll give you" + _offerValue + " for it");
        }

        else if (_negotiationRound <= 3)
        {
            Debug.Log("Round smaller than 3");
            if (_counterOfferValue >= (_originalPrice * 2))
            {
                Debug.Log("Counter Offer more or equal than double");
                var _failChance = Random.Range(1, 10);
                if (_failChance < 2)
                {
                    _negotiationRound++;
                    _negotiationSuccess = true;
                    _negotiationActive = false;
                    _finalPrice = _counterOfferValue;
                    Debug.Log(GreenBartPhrases(_negotiationSuccess));
                }
                else if (_failChance < 8)
                {
                    _negotiationRound++;
                    _offerValue = CotinueNegotiating();
                    _negotiationActive = true;
                    _finalPrice = _offerValue;
                    Debug.Log("That's a little high...How about " + _finalPrice + "?");
                }
                else
                {
                    _finalPrice = _counterOfferValue;
                    _uiManager.AddCoins(_finalPrice);
                    _negotiationActive = false;
                    _negotiationSuccess = true;
                    _negotiationRound = 0;
                    Debug.Log(GreenBartPhrases(_negotiationSuccess));
                }
            }
            else
            {
                Debug.Log("Counter Offer less than double");
                var _failChance = Random.Range(1, 10);
                if (_failChance < 5)
                {
                    _negotiationRound++;
                    _negotiationSuccess = true;
                    _negotiationActive = false;
                    _finalPrice = _counterOfferValue;
                    Debug.Log(GreenBartPhrases(_negotiationSuccess));
                }
                else if (_failChance < 9)
                {
                    _negotiationRound++;
                    _offerValue = CotinueNegotiating();
                    _negotiationActive = true;
                    _finalPrice = _offerValue;
                    Debug.Log("That's a little high...How about " + _finalPrice + "?");
                }
                else
                {
                    _finalPrice = _counterOfferValue;
                    _uiManager.AddCoins(_finalPrice);
                    _negotiationRound = 0;
                    _negotiationActive = false;
                    _negotiationSuccess = true;
                    Debug.Log(GreenBartPhrases(_negotiationSuccess));
                }
            }
        }

        else
        {
            Debug.Log("Round bigger than 3");
            if (_counterOfferValue >= 2)
            {
                Debug.Log("Counter Offer more or equal than double");
                var _failChance = Random.Range(1, 10);
                if (_failChance < 4)
                {
                    _negotiationRound++;
                    _negotiationSuccess = true;
                    _negotiationActive = false;
                    _finalPrice = _counterOfferValue;
                    Debug.Log(GreenBartPhrases(_negotiationSuccess));
                }
                else if (_failChance < 6)
                {
                    _offerValue = CotinueNegotiating();
                    _negotiationActive = true;
                    _finalPrice = _offerValue;
                    Debug.Log("That's a little high...How about " + _finalPrice + "?");
                }
                else
                {
                    _negotiationRound = 0;
                    _negotiationActive = false;
                    _negotiationSuccess = false;
                    _finalPrice = 0;
                    Debug.Log(GreenBartPhrases(_negotiationSuccess));
                }
            }
            else
            {
                Debug.Log("Counter Offer less than double");
                var _failChance = Random.Range(1, 10);
                if (_failChance < 4)
                {
                    _negotiationRound++;
                    _negotiationSuccess = true;
                    _negotiationActive = false;
                    _finalPrice = _counterOfferValue;
                    Debug.Log(GreenBartPhrases(_negotiationSuccess));
                }
                else if (_failChance < 6)
                {
                    _offerValue = CotinueNegotiating();
                    _negotiationActive = true;
                    _finalPrice = _offerValue;
                    Debug.Log("That's a little high...How about " + _finalPrice + "?");
                }
                else
                {
                    _negotiationRound = 0;
                    _negotiationActive = false;
                    _negotiationSuccess = false;
                    _finalPrice = 0;
                    Debug.Log(GreenBartPhrases(_negotiationSuccess));
                }
            }
         
        }
    }

    private int CotinueNegotiating()
    {
        var _counterRatio = Random.Range(0.5f, 0.9f);
        int _returnOffer = Mathf.RoundToInt(_counterOfferValue * _counterRatio);
        return _returnOffer;
    }

    private string GreenBartPhrases(bool wasNegotiationSuccesful)
    {
        if (!wasNegotiationSuccesful)
        {
            var _phraseChoice = Random.Range(1, 2);

            if (_phraseChoice == 1)
            {
                return "Parrots bite me!! You're an insistent one huh? Since you don't want to negotiate fair go flying to another store!";
            }
            else
            {
                return "Easy there, you're no hawk to be flying so high, I'll pass for now";
            }
        }
        else
        {
            var _phraseChoice = Random.Range(1, 4);

            switch (_phraseChoice)
            {
                case 1:
                    return "I knew you were a smart pirate, the pun wasn't one of the best but at least the prices were. Go back to hunting your treasures";
                case 2:
                    return "By White Beard sakes, this is a great deal. I gave you less credit than you deserve";
                case 3:
                    return "You're gonna make me featherless this way, but since it's for you, I'll accept";
                default:
                    return "This is making me lose money, but I'll do it just this once";
            }
        }
    }
}
