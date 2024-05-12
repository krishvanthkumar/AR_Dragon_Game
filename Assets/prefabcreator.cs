using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class prefabcreator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject dragonPrefab;
    [SerializeField] private Vector3 PrefabOffset;
    private GameObject dragon;
    private ARTrackedImageManager aRTrackedImageManager;

    private void OnEnable(){
        aRTrackedImageManager  = gameObject.GetComponent<ARTrackedImageManager>();
        aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs obj){
        foreach (ARTrackedImage image in obj.added){
            dragon =Instantiate(dragonPrefab,image.transform);
            dragon.transform.position += PrefabOffset;

        }
    }
}
