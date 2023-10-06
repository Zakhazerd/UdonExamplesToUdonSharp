
using UdonSharp;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using VRC.SDKBase;
using VRC.Udon;

public class OnMouseEvent : UdonSharpBehaviour
{
    public string eventName;
    public UdonBehaviour target;
    void OnMouseDown()
    {
        target.SendCustomEvent(eventName);
    //    Debug.Log("mouse down");
    }
}
