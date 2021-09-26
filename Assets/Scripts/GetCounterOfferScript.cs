using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCounterOfferScript : MonoBehaviour
{
    public InputField _inputField;
    public int _counterOffer;

    private string _counterOfferInput;

    private void Start()
    {
        _inputField.ActivateInputField();
    }

    // Update is called once per frame
    void Update()
    {
        _counterOfferInput = _inputField.text;
        var _tempOffer = int.TryParse(_counterOfferInput, out int counter);
        _counterOffer = counter;
    }
}