using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class prefabdata : MonoBehaviour
{
    [SerializeField] private GameObject Tankprefab;
    [SerializeField] private Vector3 prefabOffset;
    private GameObject tank;
    private ARTrackedImageManager aRTrackedImageManager;

    private void OnEnable() // Added parentheses
    {
        aRTrackedImageManager = GetComponent<ARTrackedImageManager>(); // Removed "gameObject." and changed "gameObject.GetComponent<ARTrackedImageManager>()" to "GetComponent<ARTrackedImageManager>()"
        aRTrackedImageManager.trackedImagesChanged += OnImageChanged; // Changed "aRTrackedImageManager.TrackedImagesChanged" to "aRTrackedImageManager.trackedImagesChanged"
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs obj)
    {
        foreach (ARTrackedImage image in obj.added)
        {
            tank = Instantiate(Tankprefab, image.transform);
            tank.transform.position += prefabOffset; // Added semicolon
        }
    }
}

