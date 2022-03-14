using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaneFinder : MonoBehaviour
{
    #region Public variables 
    [HideInInspector] public Pose pose;
    #endregion

    #region Private variables
    [SerializeField] private Camera cam;
    [SerializeField] private Transform indicator;

    private ARRaycastManager arRaycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    #endregion

    #region Main methods
    private void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }
    #endregion

    #region Finding plane helper methods
    // Tracking planes.
    public void PlaneFind()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        hits.Clear();
        arRaycastManager.Raycast(ray, hits, TrackableType.Planes);

        if (hits.Count > 0)
            pose = hits[0].pose;

        IndicatorController();
    }
    #endregion

    #region Indicator helper methods
    // Set indicator's postion and rotation relative to camera direction.
    private void IndicatorController()
    {
        indicator.position = pose.position;
        indicator.rotation = Quaternion.LookRotation(new Vector3(cam.transform.forward.x, 0f, cam.transform.forward.z).normalized);
    }

    public void DisableDetection()
    {
        indicator.gameObject.SetActive(false);
        arRaycastManager.enabled = false;
    }
    #endregion
}