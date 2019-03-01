using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaze : MonoBehaviour {
    // public GameObject SwitchVideoText;

    /// <summary> 
    /// Provides Singleton-like behaviour to this class. 
    /// </summary> 
    public static Gaze instance;

    /// <summary> 
    /// Provides a reference to the object the user is currently looking at. 
    /// </summary> 
    public GameObject FocusedGameObject { get; private set; }

    /// <summary> 
    /// Provides a reference to compare whether the user is still looking at 
    /// the same object (and has not looked away). 
    /// </summary> 
    private GameObject oldFocusedObject = null;

    /// <summary> 
    /// Max Ray Distance 
    /// </summary> 
    float gazeMaxDistance = 300;

    /// <summary> 
    /// Provides whether an object has been successfully hit by the raycast. 
    /// </summary> 
    public bool Hit { get; private set; }

    private void Awake() {
        // Set this class to behave similar to singleton 
        instance = this;
    }

    void Start() {
        FocusedGameObject = null;
    }

    // Update is called once per frame
    void Update() {
        // Set the old focused gameobject. 
        oldFocusedObject = FocusedGameObject;
        RaycastHit hitInfo;

        // Initialise Raycasting. 
        Hit = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo, gazeMaxDistance);

        // Check whether raycast has hit. 
        if (Hit == true) {
            // Check whether the hit has a collider. 
            if (hitInfo.collider != null) {
                // Set the focused object with what the user just looked at. 
                FocusedGameObject = hitInfo.collider.gameObject;
            }
            else {
                // Object looked on is not valid, set focused gameobject to null. 
                FocusedGameObject = null;
            }
        }
        else {
            // No object looked upon, set focused gameobject to null.
            FocusedGameObject = null;
        }

        // Check whether the previous focused object is this same 
        // object (so to stop spamming of function). 
        if (FocusedGameObject != oldFocusedObject) {
            // Compare whether the new Focused Object has the desired tag we set previously. 
            //if (FocusedGameObject.CompareTag("GazeButton")) {
            if (FocusedGameObject != null && FocusedGameObject.CompareTag("SwitchScene")) {
                //SwitchVideoText.SetActive(false);
                VideoControllerNew.instance.ChangeVideo(/*SwitchVideoText*/);
            }
        }
    }
}
