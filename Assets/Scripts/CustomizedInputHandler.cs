using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using HoloToolkit.Unity.InputModule;
using UnityEngine.XR.WSA.Input;

public class CustomizedInputHandler : MonoBehaviour, IInputHandler {
    public GameObject menu;
    GameObject left_tooltip;
    GameObject right_tooltip;
    public void OnInputDown(InputEventData eventData) {
        if (eventData.PressType.Equals(InteractionSourcePressInfo.Grasp))
        {
            eventData.Use();
            if (left_tooltip == null || right_tooltip == null) {
                left_tooltip = GameObject.Find("_ToolTips_Left");
                right_tooltip = GameObject.Find("_ToolTips_Right");
            }
            if (left_tooltip.activeSelf)
            {
                left_tooltip.SetActive(false);
                right_tooltip.SetActive(false);
            }
            else
            {
                left_tooltip.SetActive(true);
                right_tooltip.SetActive(true);
            }
        }
        if (eventData.PressType.Equals(InteractionSourcePressInfo.Menu))
        {
            eventData.Use();
            if (menu.activeSelf)
            {
                menu.SetActive(false);
            }
            else {
                menu.SetActive(true);
            }
        }
    }

    public void OnInputUp(InputEventData eventData) {
    
    }

}
