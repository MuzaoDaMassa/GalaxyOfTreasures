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
            _buttonImage.GetComponent<Transform>().position = new Vector3(this.transform.position.x, 17.07f, this.transform.position.z);
            _buttonImage.GetComponent<Transform>().localScale = new Vector3(this.transform.localScale.x, 3.41f, this.transform.localScale.z);
            _standardPlayerSkinIsActive = true;
        }

    }
}
