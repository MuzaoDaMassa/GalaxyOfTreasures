using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager_GameScene : MonoBehaviour
{
    public Text _cointsText;

    private void Start()
    {
        _cointsText.text = PlayerPrefs.GetInt("CoinAmount").ToString();
    }
}
