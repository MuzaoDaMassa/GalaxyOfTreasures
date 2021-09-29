using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenBartScript : MonoBehaviour
{
    public int _offerValue;
    public int _counterOfferValue;
    public int _finalPrice;
    public int _originalPrice;
    public int _negotiationRound = 1;
    public int _maxRounds;
    //public bool _playerOffer;
    public bool _negotiationStarted = false;
    public bool _waitingForPlayer = false;
    public bool _negotiationActive, _negotiationSuccess = false;
    public GameObject _negotiationArea, _storeOptionArea;
    public GameObject _acceptOfferButton, _counterOfferButton, _cancelTradeButton;
    public GameObject[] _commonButtons;
    public UIManager_Store _uiManager;
    public Image _greenBartImage;
    public Text _initialOfferText;
    public Sprite _greenBartMad, _greenBartHappy, _greenBartWelcome;


    private GameObject _activeTreasure;

    private void Start()
    {
        _greenBartImage = GetComponent<Image>();
    }

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
        _negotiationRound = 1;


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
            _initialOfferText.text = "That's a nice Item! I'll give you " + _offerValue + " for it";
            //Debug.Log("That's a nice Item! I'll give you" + _offerValue + " for it");
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
                    _initialOfferText.text = GreenBartActions(_negotiationSuccess);
                    //Debug.Log(GreenBartActions(_negotiationSuccess));
                }
                else if (_failChance < 8)
                {
                    _negotiationRound++;
                    _offerValue = CotinueNegotiating();
                    _negotiationActive = true;
                    _finalPrice = _offerValue;
                    _initialOfferText.text = "That's a little high...How about " + _finalPrice + "?";
                    //Debug.Log("That's a little high...How about " + _finalPrice + "?");
                }
                else
                {
                    _finalPrice = _counterOfferValue;
                    _uiManager.AddCoins(_finalPrice);
                    _negotiationActive = false;
                    _negotiationSuccess = true;
                    _negotiationRound = 0;
                    _negotiationArea.SetActive(false);
                    _storeOptionArea.SetActive(true);
                    _initialOfferText.text = GreenBartActions(_negotiationSuccess);
                    //Debug.Log(GreenBartActions(_negotiationSuccess));
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
                    _initialOfferText.text = GreenBartActions(_negotiationSuccess);
                    //Debug.Log(GreenBartActions(_negotiationSuccess));
                }
                else if (_failChance < 9)
                {
                    _negotiationRound++;
                    _offerValue = CotinueNegotiating();
                    _negotiationActive = true;
                    _finalPrice = _offerValue;
                    _initialOfferText.text = "That's a little high...How about " + _finalPrice + "?";
                    //Debug.Log("That's a little high...How about " + _finalPrice + "?");
                }
                else
                {
                    _finalPrice = _counterOfferValue;
                    _uiManager.AddCoins(_finalPrice);
                    _negotiationRound = 0;
                    _negotiationActive = false;
                    _negotiationSuccess = true;
                    _negotiationArea.SetActive(false);
                    _storeOptionArea.SetActive(true);
                    _initialOfferText.text = GreenBartActions(_negotiationSuccess);
                    //Debug.Log(GreenBartActions(_negotiationSuccess));
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
                    _uiManager.AddCoins(_finalPrice);
                    _negotiationArea.SetActive(false);
                    _storeOptionArea.SetActive(true);
                    _initialOfferText.text = GreenBartActions(_negotiationSuccess);
                    //Debug.Log(GreenBartActions(_negotiationSuccess));
                }
                else if (_failChance < 6)
                {
                    _offerValue = CotinueNegotiating();
                    _negotiationActive = true;
                    _finalPrice = _offerValue;
                    _initialOfferText.text = "That's a little high...How about " + _finalPrice + "?";
                    //Debug.Log("That's a little high...How about " + _finalPrice + "?");
                }
                else
                {
                    _negotiationRound = 0;
                    _negotiationActive = false;
                    _negotiationSuccess = false;
                    _finalPrice = 0;
                    _initialOfferText.text = GreenBartActions(_negotiationSuccess);
                    //Debug.Log(GreenBartActions(_negotiationSuccess));
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
                    _uiManager.AddCoins(_finalPrice);
                    _negotiationArea.SetActive(false);
                    _storeOptionArea.SetActive(true);
                    _initialOfferText.text = GreenBartActions(_negotiationSuccess);
                    //Debug.Log(GreenBartActions(_negotiationSuccess));
                }
                else if (_failChance < 6)
                {
                    _offerValue = CotinueNegotiating();
                    _negotiationActive = true;
                    _finalPrice = _offerValue;
                    _initialOfferText.text = "That's a little high...How about " + _finalPrice + "?";
                    //Debug.Log("That's a little high...How about " + _finalPrice + "?");
                }
                else
                {
                    _negotiationRound = 0;
                    _negotiationActive = false;
                    _negotiationSuccess = false;
                    _finalPrice = 0;
                    _initialOfferText.text = GreenBartActions(_negotiationSuccess);
                    //Debug.Log(GreenBartActions(_negotiationSuccess));
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

    private string GreenBartActions(bool wasNegotiationSuccesful)
    {
        if (!wasNegotiationSuccesful)
        {
            var _phraseChoice = Random.Range(1, 2);

            if (_phraseChoice == 1)
            {
                _greenBartImage.sprite = _greenBartMad;
                return "Parrots bite me!! You're an insistent one huh? Since you don't want to negotiate fair go flying to another store!";
            }
            else
            {
                _greenBartImage.sprite = _greenBartMad;
                return "Easy there, you're no hawk to be flying so high, I'll pass for now";
            }   
        }
        else
        {
            var _phraseChoice = Random.Range(1, 4);

            switch (_phraseChoice)
            {
                case 1:
                    _greenBartImage.sprite = _greenBartHappy;
                    return "I knew you were a smart pirate, the pun wasn't one of the best but at least the prices were. Go back to hunting your treasures";
                case 2:
                    _greenBartImage.sprite = _greenBartHappy;
                    return "By White Beard sakes, this is a great deal. I gave you less credit than you deserve";
                case 3:
                    _greenBartImage.sprite = _greenBartHappy;
                    return "You're gonna make me featherless this way, but since it's for you, I'll accept";
                default:
                    _greenBartImage.sprite = _greenBartHappy;
                    return "This is making me lose money, but I'll do it just this once";
            }
        }
    }
}
