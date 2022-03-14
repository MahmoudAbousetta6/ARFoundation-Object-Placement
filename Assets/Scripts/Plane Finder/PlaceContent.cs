using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlaceContent : MonoBehaviour
{
    #region Private variables
    [SerializeField] private GameObject contentToPlace;
    private PlaneFinder planeFinder;
    private bool contentAdded = false;
    #endregion

    #region Main methods
    private void Awake()
    {
        planeFinder = GetComponent<PlaneFinder>();
    }
    #endregion

    #region Content placing helper methods
    // Place objects.
    public void PlaceObjects()
    {
        if (contentAdded) return;

        planeFinder.DisableDetection();

        Instantiate(contentToPlace, planeFinder.pose.position, planeFinder.pose.rotation);

        contentAdded = true;
    }
    #endregion
}
