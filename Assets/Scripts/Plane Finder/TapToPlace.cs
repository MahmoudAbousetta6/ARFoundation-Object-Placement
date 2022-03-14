using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToPlace : MonoBehaviour
{
    #region Private variables
    private PlaneFinder planeFinder;
    private PlaceContent placeContent;
    #endregion

    #region Main methods
    private void Awake()
    {
        planeFinder = GetComponent<PlaneFinder>();
        placeContent = GetComponent<PlaceContent>();
    }
    private void Update()
    {
        planeFinder.PlaneFind();
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            placeContent.PlaceObjects();
        }
    }
    #endregion
}