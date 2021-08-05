using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigButton : MonoBehaviour
{
    public int _digsCounter = 0;
    public bool _isTreasurefound = false;

    public GameObject tryAgainText, chestFoundText;
    public GameObject chestPrefab;
    public GameObject treasurePrefab;
    [HideInInspector]
    public Transform chestPosition;

    private CreateDiggingAnchor diggingAnchor;

    private void Awake()
    {
        diggingAnchor = GameObject.Find("AR Session Origin").GetComponent<CreateDiggingAnchor>();
    }


    public void DigButtonPressed()
    {
        int _treasureChance = Random.Range(1, 11);
        _digsCounter++;

        if (_digsCounter == 1)
        {
            if (_treasureChance > 8)
            {
                TreasureFound();
            }
            else
            {
                StartCoroutine(TryAgainTextRoutine());
            }
        }

        if (_digsCounter == 2)
        {
            if (_treasureChance > 6)
            {
                TreasureFound();
            }
            else
            {
                StartCoroutine(TryAgainTextRoutine());
            }
        }

        if (_digsCounter == 3)
        {
            if (_treasureChance > 4)
            {
                TreasureFound();
            }
            else
            {
                StartCoroutine(TryAgainTextRoutine());
            }
        }

        if (_digsCounter == 4)
        {
            if (_treasureChance > 1)
            {
                TreasureFound();
            }
            else
            {
                StartCoroutine(TryAgainTextRoutine());
            }
        }
    }

    IEnumerator TryAgainTextRoutine()
    {
        tryAgainText.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        tryAgainText.SetActive(false);
        Destroy(diggingAnchor.landmark.gameObject);
        this.gameObject.SetActive(false);
    }

    private void TreasureFound()
    {
        Instantiate(chestPrefab, chestPosition.position, Quaternion.identity);
        chestFoundText.SetActive(true);
        _isTreasurefound = true;
    }
}
