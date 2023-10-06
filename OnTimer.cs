
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class OnTimer : UdonSharpBehaviour
{
    public UdonBehaviour target;
    public string eventName;
    public float duration;
    private float lastTimerTick = 0;
    void Update()
    {
        if(Time.time - lastTimerTick > duration)
        {
            target.SendCustomEvent(eventName);
            lastTimerTick = Time.time;
        }
    }
}
