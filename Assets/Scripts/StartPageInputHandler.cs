using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using HoloToolkit.Unity.InputModule;
using UnityEngine.XR.WSA.Input;

public class StartPageInputHandler : MonoBehaviour, IInputHandler {
    public void OnInputDown(InputEventData eventData) {
        if (eventData.PressType.Equals(InteractionSourcePressInfo.Select)) {
            //Debug.Log("eventData");
            gameObject.SetActive(false);
            //SceneManager.LoadScene("VideoScene0");
            SceneManager.LoadScene("StreamingScene", LoadSceneMode.Additive);
            //SceneManager.LoadScene("AVScene", LoadSceneMode.Additive);
        }
    }

    public void OnInputUp(InputEventData eventData) {
        
    }
}
