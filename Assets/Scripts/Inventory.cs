using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int _coins = 0;

    public GameObject[] _treasures;
    public GameObject _playerObj;

    public Material _standardMaterial;
    public Material _toyShipMaterial;
    public Image _buttonImage;

    public Sprite _standardSkinSprite;
    public Sprite _toyShipSkinSprite;

    private bool _standardPlayerSkinIsActive = false;

    private void Awake()
    {
       if (PlayerPrefs.HasKey("CoinAmount"))
        {
            _coins = PlayerPrefs.GetInt("CoinAmount");
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSkin()
    {
        if(_standardPlayerSkinIsActive)
        {
            _playerObj.GetComponent<MeshRenderer>().material = _toyShipMaterial;
            _standardPlayerSkinIsActive = false;
            _buttonImage.GetComponent<Image>().sprite = _standardSkinSprite;
        }
        else if(!_standardPlayerSkinIsActive)
        {
            _playerObj.GetComponent<MeshRenderer>().material = _standardMaterial;
            _buttonImage.GetComponent<Image>().sprite = _toyShipSkinSprite;
            _standardPlayerSkinIsActive = true;
        }

    }
}
