using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager_Store : MonoBehaviour
{
    private int _playersCoins;
    private TreasureScript[] _treasureScript;

    public GameObject[] _commonTreasures;
    public Text _coinsText;
    public Inventory _inventory;

    // Start is called before the first frame update
    void Awake()
    {
        _inventory = GameObject.Find("Players_Inventory").GetComponent<Inventory>();
        GetCommonTreasures();
        Debug.Log(_commonTreasures[0].GetComponent<TreasureScript>()._treasureName);
    }

    // Update is called once per frame
    void Update()
    {
        _playersCoins = _inventory._coins;
        _coinsText.text = _playersCoins.ToString();
    }

    
    public void GetCommonTreasures()
    {
        GameObject[] _treasures = _inventory._treasures;
        _treasureScript = new TreasureScript[_treasures.Length];
        _commonTreasures = new GameObject[_treasures.Length];
        for (int i = 0; i < _treasures.Length; i++)
        {
            _treasureScript[i] = _treasures[i].GetComponent<TreasureScript>();
            if (_treasureScript[i]._treasureRarity == "Common")
            {
                _commonTreasures[i] = _treasures[i];
            }

        }
    }

    public void AddCoins(int finalPrice)
    {
        _inventory._coins += finalPrice;
        PlayerPrefs.SetInt("CoinAmount", _inventory._coins);
    }
}
