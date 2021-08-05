using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class CreateDiggingAnchor : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    private DigButton digButtonScript;

    public GameObject digButton, leaveButton;
    public GameObject landmarkPrefab;
    [HideInInspector]
    public GameObject landmark;

    static List<ARRaycastHit> s_hits = new List<ARRaycastHit>();

    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        digButtonScript = digButton.GetComponent<DigButton>();
        digButton.SetActive(false);
    }

    private bool TryToGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!TryToGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }

        if (raycastManager.Raycast(touchPosition, s_hits, TrackableType.PlaneWithinPolygon) && !digButton.activeSelf)
        {
            SpawnChestLocation();
        }

        if (digButtonScript._isTreasurefound && landmark != null)
        {
            digButton.SetActive(false);
            Destroy(landmark);
            leaveButton.SetActive(true);
        }
    }

    private void SpawnChestLocation()
    {
        var hitPose = s_hits[0].pose;
        if (landmark == null)
        {
            landmark = Instantiate(landmarkPrefab, hitPose.position, Quaternion.identity);
            digButtonScript.chestPosition = landmark.transform;
            digButton.SetActive(true);
        }
        else
        {
            landmark.transform.position = hitPose.position;
            landmark.transform.rotation = hitPose.rotation;
        }
    }
}
